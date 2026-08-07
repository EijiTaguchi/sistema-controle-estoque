import type { LucideIcon } from "lucide-react";
import { NavLink } from "react-router-dom";

type NavItemProps = {
    to: string;
    label: string;
    icon: LucideIcon
};

export function NavItem({
    to,
    label,
    icon: Icon
}: NavItemProps) {
    return (
        <NavLink 
        to={to}
        className={({ isActive}) =>
            `flex items-center gap-3 rounded-lg px-3 py-2 transition-colors ${
                isActive 
                ? "bg-primary text-primary-foreground" 
                : "text-muted-foreground hover:bg-muted"
            }`
        }
    >
        <Icon size={20} />
        <span>{label}</span>
    </NavLink>
    );
}