/**
 * 演示程序当前的 “注册/登录” 等操作，是基于 “本地存储” 完成的
 * 当您要参考这个演示程序进行相关 app 的开发时，
 * 请注意将相关方法调整成 “基于服务端Service” 的实现。
 **/
(function($, owner) {

	owner.login=function(loginInfo,callback){
		callback=callback || $.noop;
		loginInfo.account = loginInfo.account || '';
		loginInfo.password = loginInfo.password || '';
		
		if(loginInfo.account.length<6){
			return callback("账号最短为 5 个字符");
		}
		if(loginInfo.password.length<6){
			return callback('密码最短为 6 个字符');
		}
		
		var users=JSON.parse(localStorage.getItem("$users") || '[]');
		var authed=users.some(function(user){
			return user.account=loginInfo.account && user.password== loginInfo.password;
		});
		
		if(authed){
			return owner.createState(loginInfo.account,callback);
		}
		else{
			return callback('用户名或密码错误');
		}
	};	
	
	/*
	 * 注册用户信息
	 */
	owner.reg=function(regInfo,callback){
		callback=callback||$.noop;
		regInfo=regInfo ||{};
		regInfo.account = regInfo.account || '';
		regInfo.password = regInfo.password || '';
		
		if(regInfo.account.length<5){
			return callback("");
		}
		if(regInfo.password.length<5){
			return callback("");
		}
		if(!checkEmail(regInfo.email)){
			return callback('密码最短为 6 个字符');
		}
		var users=JSON.parse(localStorage.getItem("$users") || '[]');
		users.push(regInfo);
		localStorage.setItem('$users',JSON.stringify(users));
		return callback();
	};


	owner.createState = function(name, callback) {
		var state = owner.getState();
		state.account = name;
		state.token = "token123456789";
		owner.setState(state);
		return callback();
	};

	/**
	 * 获取当前状态
	 **/
	owner.getState = function() {
		var stateText = localStorage.getItem('$state') || "{}";
		return JSON.parse(stateText);
	};

	/**
	 * 设置当前状态
	 **/
	owner.setState = function(state) {
		state = state || {};
		localStorage.setItem('$state', JSON.stringify(state));
		//var settings = owner.getSettings();
		//settings.gestures = '';
		//owner.setSettings(settings);
	};

	/**
	 * 获取应用本地配置
	 **/
	owner.setSettings = function(settings) {
		settings = settings || {};
		localStorage.setItem('$settings', JSON.stringify(settings));
	}

	/**
	 * 设置应用本地配置
	 **/
	owner.getSettings = function() {
		var settingsText = localStorage.getItem('$settings') || "{}";
		return JSON.parse(settingsText);
	}
	
	/*
	 * 检测Email地址
	 */
	var checkEmail = function(email) {
		email=email ||"";
		return (email.length>3 && email.indexOf('@')>-1);
	};
}(mui, window.app = {}));