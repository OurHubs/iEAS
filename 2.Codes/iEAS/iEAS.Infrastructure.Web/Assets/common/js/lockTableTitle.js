/*
 * ����ͷ����.
 * ���ܽ���:
 * ��񳬹���ʾ��Χʱ,ˮƽ�ƶ�������ͷ����֮�ƶ�,��ֱ�ƶ�������ͷ���������϶�.
 * �����ڱ����Сʱ������ݴ���Ĵ�С��֮���иı�
 * ����ɶ�̬���,������ݶ�̬�����ʾ/������������Զ����������С
 * ע������:
 * ���������JQuery
 * �����ֻ֧�ֱ����100%չʾ.����ֲ�ʹ�ñ��,��ʹ��Frame��iFrame
 * ʹ�÷���:
 * 1.����Ҫ���������ͷ���������div.
 * 2.ҳ�����     
    var locktb;
    $(function(){
        locktb=new Kkctf.table.lockTableSingle({
            tMain:$('#lockTable'),            //table�Ĳ�
            padWidth:0,                        //��Ԫ�����ҵ�padding��ֵ�ܺ���ֵ
            borWidth:2,                    //������ұ߿����ܺ�ֵ
            subtHeig:60,                    //���߶ȼ�ȥ����
            dinamicDiv:$('#dynamicDiv'),      //��̬��ĸ߶�.������ݶ�̬�����ʾ�����ؽ��б���С�Ķ�̬����(��ѡ)
            autoHeight:true                 //��񴰿��Ƿ����Ŵ��ڵĸ߶ȸı��Զ������߶�(��ѡ)
        });
    });
 * 3.�ֶ��������ڸ߶� locktb.autoHeightFn();
 * 
 */
Kkctf = {};
Kkctf.apply = function(o, c, defaults){
    if(defaults){
        Kkctf.apply(o, defaults);
    }
    if(o && c && typeof c == 'object'){
        for(var p in c){
            o[p] = c[p];
        }
    }
    return o;
};

Kkctf.bind = function(el,ename,fn,scope){
    el.bind(ename,function(e){
        fn.apply(scope);
    })
};

Kkctf.table = Kkctf.table || {};

Kkctf.table.lockTableSingle = function(configs){
    Kkctf.apply(this,configs);
    this.init();
    Kkctf.apply(this,{
            tBody:$('#tBody'),//����
            tHead:$('#tHead') //��ͷ
        });
    this.work();
    this.cssStyle();
    this.addBind();
    this.autoHeightFn();
}

Kkctf.apply(Kkctf.table.lockTableSingle.prototype,{
    init:function(){//��ʼ��������ͷ
        var tb=this.tMain.find('table').eq(0);
        tb.wrap('<div id=\'tBody\'></div>');
        
        var tBody=$('#tBody');
        tBody.before('<div id=\'tHead\'><div></div></div>');
        
        var tHead=$('#tHead');
        var tp=tb.clone().empty().append(tb.find('tr').eq(0).clone());
        
        tHead.find('div').eq(0).append(tp);    
    },
    work:function(){//ִ�б�ͷ���ÿһ����Ԫ������Ŀ��һ��
        //�������ϲ��һ���е����е�Ԫ��
        var allCols=this.tMain.find('#tBody').eq(0).find('tr').eq(0).find('td');
        var allHrd=this.tHead.find('td');
        
        var countWidth=0;
        var padWid=this.padWidth;
        
        //���ñ�ͷ����td��Ⱥͱ���һ��
        allCols.each(function(n){
            var tdWidth=$(this).width();
            allHrd.eq(n).width(tdWidth);
            countWidth+=tdWidth+padWid;
        });
        this.tBody.find('table').width(countWidth+20);
        this.tHead.find('div').width(countWidth+this.borWidth*allCols.length);

    },
    cssStyle:function(){//����scc
        this.tBody.css({
            width:'100%',
            height:$(window).height()-this.getDinamicHeight()-this.subtHeig+'px',
            overflow:'auto'
        });
        
        this.tHead.css({
            width:'100%',
            overflow:'hidden',
            position:'absolute',
            'z-index':'10'
        });
        
        this.tMain.css({
            position:'relative'
        });
    },
    addBind:function(){//����¼�
        Kkctf.bind(this.tBody,'scroll',this.scrollFn,this);
        if(this.autoHeight){
            Kkctf.bind($(window),'resize',this.autoHeightFn,this);
        }
    },
    scrollFn:function(){//��ͷƽ���¼�
        this.tHead.scrollLeft(this.tBody.scrollLeft());
    },
    autoHeightFn:function(){//����߶��¼�
        var h=$(window).height()-this.getDinamicHeight()-this.subtHeig;
        this.tBody.height(h);
    },
    getDinamicHeight:function(){//��ȡ��̬��ĸ߶�

        if(!this.dinamicDiv){
            return 0;
        }
    
        if(1>this.dinamicDiv.length){
            return 0;
        }
        
        if(this.dinamicDiv.is(':hidden')){
            return 0;
        }
        
        return this.dinamicDiv.height();
    }
})
