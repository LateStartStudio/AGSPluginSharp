/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
#include "agsplugin.h"
typedef void (*UnserializeCallback)(int key, const char *serializedData, int dataSize);

class ManagedObjectReader : public IAGSManagedObjectReader {
private:
     UnserializeCallback unserializeCallback;
public:
    ManagedObjectReader(UnserializeCallback uc)
    {
        unserializeCallback = uc;
    }

    virtual void Unserialize(int key, const char *serializedData, int dataSize) {
        (*unserializeCallback)(key, serializedData, dataSize);
    }
};
