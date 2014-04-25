
function TripperLocation(tl) {
    this.name = tl.name;
    this.Snaps = new Array();

    this.HasSnap = function (account) {
        for (i in this.Snaps) {
            if (this.Snaps[i].account == account) return true;
        }
        return false;
    }
    this.GetSnap = function (account) {
        for (i in this.Snaps) {
            if (this.Snaps[i].account == account) return this.Snaps[i];
        }
    }

    this.ShowName = function () { console.log(this.name); }
};

TripperLocation.prototype.UpdateSnap = function (account, name, time, nation, city) {
    var snap = this.GetSnap(account);
    if (snap == undefined) {
        //snap = new TripperSnap({ account: account, name: name, lng: lng, lat: lat, time: time, nation: nation, city: city });
        snap = new TripperSnap({ name: name, account: account, time: time, nation: nation, city: city });

        this.Snaps.push(snap);
    }
    return snap;
};
TripperLocation.prototype.GetEffectiveSnaps = function () {
    return Snaps;
};
TripperLocation.prototype.GetExpiredSnaps = function () {
    return Snaps;
};

function TripperSnap(snap) {
    this.account = snap.account;
    this.name = snap.name;
    this.time = snap.time;
    this.nation = snap.nation;
    this.city = snap.city;

    this.UpdateLngLat = function (lng, lat) {
        this.lng = lng;
        this.lat = lat;
    }

    this.GetPoint = function () {
        return this.point;
    }
    this.SetPoint = function (point) {
        this.point = point;
    }

    this.NeedToUpdate = function (lng, lat) {
        if (this.lng != lng || this.lat != lat) {
            return true;
        }
        return false;
    }
};