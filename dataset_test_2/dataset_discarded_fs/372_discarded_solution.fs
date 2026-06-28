FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(180.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(120.000000, -50.000000) * millimeter, vector(130.000000, -50.000000) * millimeter, vector(130.000000, -230.000000) * millimeter, vector(0.000000, -230.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(180.000000, 80.000000) * millimeter, vector(180.000000, -10.000000) * millimeter, vector(120.000000, -40.000000) * millimeter, vector(120.000000, -50.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(105.099338, -63.377483, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 3 from 1 (two_bend) ===
        // Flange 1->1_1_3: bend=86.64deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, -140.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 86.639394 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1_3
        var wallFace1_1_3a = qClosestTo(qCreatedBy(id + "flange1_1_1_3a", EntityType.FACE), vector(50.293100, -140.000000, 4.991402) * millimeter);
        var faceN1_1_3a = evPlane(context, { "face" : wallFace1_1_3a }).normal;
        var skN1_1_3a = dot(faceN1_1_3a, vector(-0.998280368, 0.0, 0.0586200216)) >= 0 ? faceN1_1_3a : -faceN1_1_3a;
        var sketchRem1_1_3a = newSketchOnPlane(context, id + "sketchRem1_1_3a", { "sketchPlane" : plane(vector(50.5862, -50.0, 9.9828) * millimeter, skN1_1_3a, vector(-0.0586200216, 0.0, -0.998280368)) });
        skPolyline(sketchRem1_1_3a, "polyRem1_1_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999996, 0.000000) * millimeter, vector(7.999996, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(-41.086454, 230.000000) * millimeter, vector(-39.086454, 240.000000) * millimeter, vector(-163.569731, 240.000000) * millimeter, vector(-165.569731, 230.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_3a);
        sheetMetalTab(context, id + "smTab1_1_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_3a"), vector(50.293100, -50.000000, 4.991402) * millimeter),
            "booleanUnionScope" : wallFace1_1_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_3->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(56.643400, -290.000000, 113.133200) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(70.0, -290.0, 50.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(21.176500, -40.000000) * millimeter, vector(19.179939, -49.882757) * millimeter, vector(56.826939, -49.882757) * millimeter, vector(58.823500, -40.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(80.000000, 120.000000) * millimeter, vector(-7.711339, 125.150557) * millimeter, vector(-15.008739, 0.881357) * millimeter, vector(-7.022400, 0.412400) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(61.634801, -290.000000, 112.840092) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_3_3b", EntityType.FACE), vector(61.634801, -290.000000, 112.840092) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });