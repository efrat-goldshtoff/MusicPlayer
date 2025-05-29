export type UserType = {
    // [x: string]: any,
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    password?: string;
    role: string;
}

export type Action = {
    type: 'CREATE' | 'UPDATE' | 'GET' | 'REMOVE',
    data: Partial<UserType>
}

export const UserReducer =
    (state: UserType, action: Action): UserType => {
        switch (action.type) {
            case 'CREATE':
                return {
                    id: action.data.id || '',
                    firstName: action.data.firstName || action.data.firstName || '', // Use name if firstName is not available
                    lastName: action.data.lastName || '',
                    email: action.data.email || '',
                    password: action.data.password, // Be careful with storing passwords
                    role: action.data.role || 'User', // Default role if not provided
                };
            case 'UPDATE':
                return { ...state, ...action.data };
            case 'REMOVE':
                return {
                    id: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    password: '',
                    role: '',
                };
            default:
                return state;
        }
    }