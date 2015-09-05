/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
#include "agsplugin.h"

typedef int (*DisposeCallback)(const char *address, bool force);
typedef const char * (*GetTypeCallback)();
typedef int (*SerializeCallback)(const char *address, char *buffer, int bufsize);

class ScriptManagedObject : public IAGSScriptManagedObject {
private:
    DisposeCallback disposeCallback;
    GetTypeCallback getTypeCallback;
    SerializeCallback serializeCallback;

public:
    ScriptManagedObject(DisposeCallback dc, GetTypeCallback gtc, SerializeCallback sc)
    {
        disposeCallback = dc;
        getTypeCallback = gtc;
        serializeCallback = sc;
    };

    virtual int Dispose(const char *address, bool force) {
       return (*disposeCallback)(address, force);
    }

    virtual const char *GetType() {
        return (*getTypeCallback)();
    }

    virtual int Serialize(const char *address, char *buffer, int bufsize) {
        return (*serializeCallback)(address, buffer, bufsize);
    }
};
