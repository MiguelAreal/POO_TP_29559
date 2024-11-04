﻿using System.Collections.Generic;


public interface IEntityController
{
    void Initialize();
    void CarregaItens();
    void FiltrarItens(string searchText, string activeColumn);
    object GetById(int id);
    void DeleteItem(object item);
}