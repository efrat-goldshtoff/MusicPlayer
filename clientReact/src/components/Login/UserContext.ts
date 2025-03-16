import { createContext } from "react"
import { UserType } from "./User"

export type UserContextType = {
    user: UserType,
    userDispatch: React.Dispatch<any>
}

export const UserContext = createContext<UserContextType | null>(null);