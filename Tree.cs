          
List<BankInfo> lstTree = _lstBank.FindAll(b => b.ParentID == "0000000000");
            List<PropertyNodeItem> lstTreeNode = new List<PropertyNodeItem>();

            lstTree.ForEach(t =>
            {
                PropertyNodeItem itm = new PropertyNodeItem() { DisplayName = t.BankName, BankId= t.BankID };
                BuildTree(itm);
                lstTreeNode.Add(itm);
            });        
        

private void BuildTree(PropertyNodeItem itm)
{
            this._lstBank.FindAll(b =>  b.ParentID == itm.BankId).ForEach(bk=>{
                itm.Children.Add(new PropertyNodeItem() { DisplayName = bk.BankName, BankId = bk.BankID });
            });
	itm.Children.ForEach(bk => { BuildTree(bk); });
}