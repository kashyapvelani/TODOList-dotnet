<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoApp.aspx.cs" Inherits="TODOList.TodoApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TODO List App</title>
	<script src="https://cdn.tailwindcss.com"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="flex items-center justify-center w-screen h-screen font-medium">
	<div class="flex flex-grow items-center justify-center h-full text-gray-600 bg-gray-100">
		<div class="max-w-full p-8 bg-white rounded-lg shadow-lg w-96">
			<div class="flex items-center mb-6">
				<svg class="h-8 w-8 text-red-500 stroke-current" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
					<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 13V6a2 2 0 00-2-2H6a2 2 0 00-2 2v7m16 0v5a2 2 0 01-2 2H6a2 2 0 01-2-2v-5m16 0h-2.586a1 1 0 00-.707.293l-2.414 2.414a1 1 0 01-.707.293h-3.172a1 1 0 01-.707-.293l-2.414-2.414A1 1 0 006.586 13H4" />
				</svg>
				<!-- Name-->
				<asp:Label ID="UserName" runat="server" Text="Kashyap's Task" CssClass="font-semibold ml-3 text-lg"/>
			</div>
			<!--New Task -->
			

			<asp:Repeater ID="TaskRepeater" runat="server" OnItemCommand="deleteTask">
				<ItemTemplate>
                    <div id="task" class="flex justify-between items-center border-b border-slate-200 py-3 px-2 border-l-4  border-l-transparent bg-gradient-to-r from-transparent to-transparent hover:from-slate-100 transition ease-linear duration-150">
                        <div class="inline-flex items-center space-x-2">
                            <div>
                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 text-slate-500 hover:text-red-600 hover:cursor-pointer">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M9 12.75L11.25 15 15 9.75M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>

                            </div>
                            <asp:Label ID="TaskList" runat="server" Text="" CssClass="ml-4 text-sm"><%# Eval("task") %></asp:Label>
                        </div>
                        <div class="flex items-center hover:cursor-pointer">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-4 h-4 text-slate-500 hover:text-slate-700">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
                            </svg>
                            <asp:Button ID="DeleteTask" runat="server" CommandName="delete" CommandArgument='<%# Eval("task") %>' Text="Delete" CssClass="hover:cursor-pointer text-gray-500 hover:text-gray-700" />
                        </div>
                    </div>
				</ItemTemplate>
			</asp:Repeater>

			<!-- Add New Task-->
			<div class="flex items-center">
			<button class="">
				
			</button>
			<asp:Button ID="AddTask" runat="server" CssClass="flex items-center h-8 px-2 mt-2 text-sm font-medium rounded bg-gray-100 text-red-500 font-bold text-lg" Text="+" OnClick="addTask" />
            <asp:TextBox ID="InputTask" runat="server" CssClass="flex-grow h-8 ml-4 bg-transparent focus:outline-none font-medium" placeholder="add a new task" ></asp:TextBox>
			
			</div>

		</div>
	</div>
		
	</div>
</div>
    </form>

</body>
</html>
