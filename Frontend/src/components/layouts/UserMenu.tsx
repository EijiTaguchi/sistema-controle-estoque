import { LogOut } from "lucide-react";
import {
  Avatar,
  AvatarFallback,
} from "../ui/avatar";
import { Button } from "../ui/button";

import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from "../ui/dropdown-menu";
import { useAuth } from "../../contexts/AuthContext";

export function UserMenu() {
  const { logout } = useAuth();
  return (
    <DropdownMenu>

      <DropdownMenuTrigger>

        <Avatar>

          <AvatarFallback>
            EO
          </AvatarFallback>

        </Avatar>

      </DropdownMenuTrigger>

      <DropdownMenuContent align="end">

        <DropdownMenuItem>
          Perfil
        </DropdownMenuItem>

        <DropdownMenuItem>
          <Button
            onClick={logout}
            variant="ghost"
            className="w-full justify-start"
          >
            <LogOut className="mr-2 h-4 w-4" />
            Sair
          </Button>
        </DropdownMenuItem>

      </DropdownMenuContent>

    </DropdownMenu>
  );
}