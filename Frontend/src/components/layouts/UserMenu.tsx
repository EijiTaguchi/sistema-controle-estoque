import {
  Avatar,
  AvatarFallback,
} from "../ui/avatar";

import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from "../ui/dropdown-menu";

export function UserMenu() {
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
          Sair
        </DropdownMenuItem>

      </DropdownMenuContent>

    </DropdownMenu>
  );
}