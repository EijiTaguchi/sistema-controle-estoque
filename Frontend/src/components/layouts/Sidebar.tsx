import { ArrowLeftRight, LayoutDashboard, LogOut, Package, Truck, User, User } from "lucide-react";
import { NavItem } from "./NavItem";
import { Separator } from "../ui/separator";
import { Button } from "../ui/button";

export function Sidebar() {
    return (
        <aside className="flex h-screen w-64 flex-col border-r bg-background p-4">
            <h2 className="mb-8 text-xl font-bold">Estoque</h2>

            <nav className="space-y-2">

                <NavItem 
                    to="/dashboard"
                    label="Dashboard"
                    icon={LayoutDashboard}
                />

                 <NavItem 
                    to="/produtos"
                    label="Produtos"
                    icon={Package}
                />

                 <NavItem 
                    to="/fornecedores"
                    label="Fornecedores"
                    icon={Truck}
                />

                <NavItem 
                    to="/movimentacoes"
                    label="Movimentações"
                    icon={ArrowLeftRight}
                />

                <NavItem 
                    to="/perfil"
                    label="Perfil"
                    icon={User}
                
                />
            </nav>

           <div className="mt-auto">

        <Separator className="my-4" />

        <Button
          variant="ghost"
          className="w-full justify-start"
        >
          <LogOut className="mr-2 h-4 w-4" />
          Sair
        </Button>

      </div>


        </aside>
    )
}