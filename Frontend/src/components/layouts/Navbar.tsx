import { Bell } from "lucide-react";
import { UserMenu } from "./UserMenu";
import { Button } from "../ui/button";
import { useLocation } from "react-router-dom";
import { pageTitles } from "../../constants/PageTitles";

export function Navbar() {

  const { pathname } = useLocation();

  const title = pageTitles[pathname] ?? "Sistema de Controle de Estoque"; 

  return (
    <header className="flex h-16 items-center justify-between border-b px-6">

      <h1 className="text-xl font-semibold">
        {title}
      </h1>

      <div className="flex items-center gap-4">

        <Button
          variant="ghost"
          size="icon"
        >
          <Bell />
        </Button>

        <UserMenu />

      </div>

    </header>
  );
}