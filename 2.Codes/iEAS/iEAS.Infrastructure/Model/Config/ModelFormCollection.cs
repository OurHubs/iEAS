﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Config
{
    [Serializable]
    public class ModelFormCollection:Collection<ModelForm>
    {
        public ModelForm GetForm(string code)
        {
            return this.FirstOrDefault(m => m.Code == code);
        }
    }
}
