/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Creates a route that is associated with a virtual router.
    /// 
    ///  
    /// <para>
    ///  You can route several different protocols and define a retry policy for a route.
    /// Traffic can be routed to one or more virtual nodes.
    /// </para><para>
    /// For more information about routes, see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/routes.html">Routes</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMSHRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.RouteData")]
    [AWSCmdlet("Calls the AWS App Mesh CreateRoute API operation.", Operation = new[] {"CreateRoute"}, SelectReturnType = typeof(Amazon.AppMesh.Model.CreateRouteResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.RouteData or Amazon.AppMesh.Model.CreateRouteResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.RouteData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateRouteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMSHRouteCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter RetryPolicy_GrpcRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify at least one of the valid values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_RetryPolicy_GrpcRetryEvents")]
        public System.String[] RetryPolicy_GrpcRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Header
        /// <summary>
        /// <para>
        /// <para>An object that represents the client request headers to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_Match_Headers")]
        public Amazon.AppMesh.Model.HttpRouteHeader[] Spec_Http2Route_Match_Header { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Header
        /// <summary>
        /// <para>
        /// <para>An object that represents the client request headers to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Header","Spec_HttpRoute_Match_Headers")]
        public Amazon.AppMesh.Model.HttpRouteHeader[] Spec_HttpRoute_Match_Header { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_RetryPolicy_HttpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify at least one of the following values.</para><ul><li><para><b>server-error</b> – HTTP status codes 500, 501, 502, 503, 504, 505, 506, 507, 508,
        /// 510, and 511</para></li><li><para><b>gateway-error</b> – HTTP status codes 502, 503, and 504</para></li><li><para><b>client-error</b> – HTTP status code 409</para></li><li><para><b>stream-error</b> – Retry on refused stream</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_RetryPolicy_HttpRetryEvents")]
        public System.String[] Spec_GrpcRoute_RetryPolicy_HttpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_RetryPolicy_HttpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify at least one of the following values.</para><ul><li><para><b>server-error</b> – HTTP status codes 500, 501, 502, 503, 504, 505, 506, 507, 508,
        /// 510, and 511</para></li><li><para><b>gateway-error</b> – HTTP status codes 502, 503, and 504</para></li><li><para><b>client-error</b> – HTTP status code 409</para></li><li><para><b>stream-error</b> – Retry on refused stream</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_RetryPolicy_HttpRetryEvents")]
        public System.String[] Spec_Http2Route_RetryPolicy_HttpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_RetryPolicy_HttpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify at least one of the following values.</para><ul><li><para><b>server-error</b> – HTTP status codes 500, 501, 502, 503, 504, 505, 506, 507, 508,
        /// 510, and 511</para></li><li><para><b>gateway-error</b> – HTTP status codes 502, 503, and 504</para></li><li><para><b>client-error</b> – HTTP status code 409</para></li><li><para><b>stream-error</b> – Retry on refused stream</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_HttpRetryEvent","Spec_HttpRoute_RetryPolicy_HttpRetryEvents")]
        public System.String[] Spec_HttpRoute_RetryPolicy_HttpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_RetryPolicy_MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of retry attempts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_RetryPolicy_MaxRetries")]
        public System.Int64? Spec_GrpcRoute_RetryPolicy_MaxRetry { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_RetryPolicy_MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of retry attempts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_RetryPolicy_MaxRetries")]
        public System.Int64? Spec_Http2Route_RetryPolicy_MaxRetry { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_RetryPolicy_MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of retry attempts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_MaxRetry","Spec_HttpRoute_RetryPolicy_MaxRetries")]
        public System.Int64? Spec_HttpRoute_RetryPolicy_MaxRetry { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to create the route in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter MeshOwner
        /// <summary>
        /// <para>
        /// <para>The AWS IAM account ID of the service mesh owner. If the account ID is not your own,
        /// then the account that you specify must share the mesh with your account before you
        /// can create the resource in the service mesh. For more information about mesh sharing,
        /// see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/sharing.html">Working
        /// with shared meshes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshOwner { get; set; }
        #endregion
        
        #region Parameter Match_Metadata
        /// <summary>
        /// <para>
        /// <para>An object that represents the data to match from the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_Match_Metadata")]
        public Amazon.AppMesh.Model.GrpcRouteMetadata[] Match_Metadata { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Method
        /// <summary>
        /// <para>
        /// <para>The client request method to match on. Specify only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.HttpMethod")]
        public Amazon.AppMesh.HttpMethod Spec_Http2Route_Match_Method { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Method
        /// <summary>
        /// <para>
        /// <para>The client request method to match on. Specify only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Method")]
        [AWSConstantClassSource("Amazon.AppMesh.HttpMethod")]
        public Amazon.AppMesh.HttpMethod Spec_HttpRoute_Match_Method { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Match_MethodName
        /// <summary>
        /// <para>
        /// <para>The method name to match from the request. If you specify a name, you must also specify
        /// a <code>serviceName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_GrpcRoute_Match_MethodName { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies the path to match requests with. This parameter must always start with <code>/</code>,
        /// which by itself matches all requests to the virtual service name. You can also match
        /// for path-based routing of requests. For example, if your virtual service name is <code>my-service.local</code>
        /// and you want the route to match requests to <code>my-service.local/metrics</code>,
        /// your prefix should be <code>/metrics</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Match_Prefix { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies the path to match requests with. This parameter must always start with <code>/</code>,
        /// which by itself matches all requests to the virtual service name. You can also match
        /// for path-based routing of requests. For example, if your virtual service name is <code>my-service.local</code>
        /// and you want the route to match requests to <code>my-service.local/metrics</code>,
        /// your prefix should be <code>/metrics</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Prefix")]
        public System.String Spec_HttpRoute_Match_Prefix { get; set; }
        #endregion
        
        #region Parameter Spec_Priority
        /// <summary>
        /// <para>
        /// <para>The priority for the route. Routes are matched based on the specified value, where
        /// 0 is the highest priority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_Priority { get; set; }
        #endregion
        
        #region Parameter RouteName
        /// <summary>
        /// <para>
        /// <para>The name to use for the route.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RouteName { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Scheme
        /// <summary>
        /// <para>
        /// <para>The client request scheme to match on. Specify only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.HttpScheme")]
        public Amazon.AppMesh.HttpScheme Spec_Http2Route_Match_Scheme { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Scheme
        /// <summary>
        /// <para>
        /// <para>The client request scheme to match on. Specify only one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Scheme")]
        [AWSConstantClassSource("Amazon.AppMesh.HttpScheme")]
        public Amazon.AppMesh.HttpScheme Spec_HttpRoute_Match_Scheme { get; set; }
        #endregion
        
        #region Parameter Match_ServiceName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name for the service to match from the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_Match_ServiceName")]
        public System.String Match_ServiceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you can apply to the route to assist with categorization and
        /// organization. Each tag consists of a key and an optional value, both of which you
        /// define. Tag keys can have a maximum character length of 128 characters, and tag values
        /// can have a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppMesh.Model.TagRef[] Tag { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_RetryPolicy_TcpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify a valid value. The event occurs before any processing of a request has started
        /// and is encountered when the upstream is temporarily or permanently unavailable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_RetryPolicy_TcpRetryEvents")]
        public System.String[] Spec_GrpcRoute_RetryPolicy_TcpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_RetryPolicy_TcpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify a valid value. The event occurs before any processing of a request has started
        /// and is encountered when the upstream is temporarily or permanently unavailable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_RetryPolicy_TcpRetryEvents")]
        public System.String[] Spec_Http2Route_RetryPolicy_TcpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_RetryPolicy_TcpRetryEvent
        /// <summary>
        /// <para>
        /// <para>Specify a valid value. The event occurs before any processing of a request has started
        /// and is encountered when the upstream is temporarily or permanently unavailable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_TcpRetryEvent","Spec_HttpRoute_RetryPolicy_TcpRetryEvents")]
        public System.String[] Spec_HttpRoute_RetryPolicy_TcpRetryEvent { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Timeout_Idle_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_Timeout_Idle_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Timeout_PerRequest_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_Timeout_PerRequest_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Timeout_Idle_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_Http2Route_Timeout_Idle_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Timeout_PerRequest_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_Http2Route_Timeout_PerRequest_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PerRetryTimeout_Unit")]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Timeout_Idle_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Timeout_Idle_Unit")]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_HttpRoute_Timeout_Idle_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Timeout_PerRequest_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Timeout_PerRequest_Unit")]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_HttpRoute_Timeout_PerRequest_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_TcpRoute_Timeout_Idle_Unit
        /// <summary>
        /// <para>
        /// <para>A unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DurationUnit")]
        public Amazon.AppMesh.DurationUnit Spec_TcpRoute_Timeout_Idle_Unit { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Timeout_Idle_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_GrpcRoute_Timeout_Idle_Value { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Timeout_PerRequest_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_GrpcRoute_Timeout_PerRequest_Value { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Timeout_Idle_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_Http2Route_Timeout_Idle_Value { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Timeout_PerRequest_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_Http2Route_Timeout_PerRequest_Value { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PerRetryTimeout_Value")]
        public System.Int64? Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Timeout_Idle_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Timeout_Idle_Value")]
        public System.Int64? Spec_HttpRoute_Timeout_Idle_Value { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Timeout_PerRequest_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Timeout_PerRequest_Value")]
        public System.Int64? Spec_HttpRoute_Timeout_PerRequest_Value { get; set; }
        #endregion
        
        #region Parameter Spec_TcpRoute_Timeout_Idle_Value
        /// <summary>
        /// <para>
        /// <para>A number of time units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Spec_TcpRoute_Timeout_Idle_Value { get; set; }
        #endregion
        
        #region Parameter VirtualRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual router in which to create the route. If the virtual router
        /// is in a shared mesh, then you must be the owner of the virtual router resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VirtualRouterName { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Action_WeightedTarget
        /// <summary>
        /// <para>
        /// <para>An object that represents the targets that traffic is routed to when a request matches
        /// the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_Action_WeightedTargets")]
        public Amazon.AppMesh.Model.WeightedTarget[] Spec_GrpcRoute_Action_WeightedTarget { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_WeightedTarget
        /// <summary>
        /// <para>
        /// <para>An object that represents the targets that traffic is routed to when a request matches
        /// the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_Action_WeightedTargets")]
        public Amazon.AppMesh.Model.WeightedTarget[] Spec_Http2Route_Action_WeightedTarget { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_WeightedTarget
        /// <summary>
        /// <para>
        /// <para>An object that represents the targets that traffic is routed to when a request matches
        /// the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_WeightedTarget","Spec_HttpRoute_Action_WeightedTargets")]
        public Amazon.AppMesh.Model.WeightedTarget[] Spec_HttpRoute_Action_WeightedTarget { get; set; }
        #endregion
        
        #region Parameter Spec_TcpRoute_Action_WeightedTarget
        /// <summary>
        /// <para>
        /// <para>An object that represents the targets that traffic is routed to when a request matches
        /// the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_TcpRoute_Action_WeightedTargets")]
        public Amazon.AppMesh.Model.WeightedTarget[] Spec_TcpRoute_Action_WeightedTarget { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Route'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.CreateRouteResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.CreateRouteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Route";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RouteName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RouteName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RouteName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RouteName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHRoute (CreateRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.CreateRouteResponse, NewAMSHRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RouteName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshOwner = this.MeshOwner;
            context.RouteName = this.RouteName;
            #if MODULAR
            if (this.RouteName == null && ParameterWasBound(nameof(this.RouteName)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Spec_GrpcRoute_Action_WeightedTarget != null)
            {
                context.Spec_GrpcRoute_Action_WeightedTarget = new List<Amazon.AppMesh.Model.WeightedTarget>(this.Spec_GrpcRoute_Action_WeightedTarget);
            }
            if (this.Match_Metadata != null)
            {
                context.Match_Metadata = new List<Amazon.AppMesh.Model.GrpcRouteMetadata>(this.Match_Metadata);
            }
            context.Spec_GrpcRoute_Match_MethodName = this.Spec_GrpcRoute_Match_MethodName;
            context.Match_ServiceName = this.Match_ServiceName;
            if (this.RetryPolicy_GrpcRetryEvent != null)
            {
                context.RetryPolicy_GrpcRetryEvent = new List<System.String>(this.RetryPolicy_GrpcRetryEvent);
            }
            if (this.Spec_GrpcRoute_RetryPolicy_HttpRetryEvent != null)
            {
                context.Spec_GrpcRoute_RetryPolicy_HttpRetryEvent = new List<System.String>(this.Spec_GrpcRoute_RetryPolicy_HttpRetryEvent);
            }
            context.Spec_GrpcRoute_RetryPolicy_MaxRetry = this.Spec_GrpcRoute_RetryPolicy_MaxRetry;
            context.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit = this.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit;
            context.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value = this.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value;
            if (this.Spec_GrpcRoute_RetryPolicy_TcpRetryEvent != null)
            {
                context.Spec_GrpcRoute_RetryPolicy_TcpRetryEvent = new List<System.String>(this.Spec_GrpcRoute_RetryPolicy_TcpRetryEvent);
            }
            context.Spec_GrpcRoute_Timeout_Idle_Unit = this.Spec_GrpcRoute_Timeout_Idle_Unit;
            context.Spec_GrpcRoute_Timeout_Idle_Value = this.Spec_GrpcRoute_Timeout_Idle_Value;
            context.Spec_GrpcRoute_Timeout_PerRequest_Unit = this.Spec_GrpcRoute_Timeout_PerRequest_Unit;
            context.Spec_GrpcRoute_Timeout_PerRequest_Value = this.Spec_GrpcRoute_Timeout_PerRequest_Value;
            if (this.Spec_Http2Route_Action_WeightedTarget != null)
            {
                context.Spec_Http2Route_Action_WeightedTarget = new List<Amazon.AppMesh.Model.WeightedTarget>(this.Spec_Http2Route_Action_WeightedTarget);
            }
            if (this.Spec_Http2Route_Match_Header != null)
            {
                context.Spec_Http2Route_Match_Header = new List<Amazon.AppMesh.Model.HttpRouteHeader>(this.Spec_Http2Route_Match_Header);
            }
            context.Spec_Http2Route_Match_Method = this.Spec_Http2Route_Match_Method;
            context.Spec_Http2Route_Match_Prefix = this.Spec_Http2Route_Match_Prefix;
            context.Spec_Http2Route_Match_Scheme = this.Spec_Http2Route_Match_Scheme;
            if (this.Spec_Http2Route_RetryPolicy_HttpRetryEvent != null)
            {
                context.Spec_Http2Route_RetryPolicy_HttpRetryEvent = new List<System.String>(this.Spec_Http2Route_RetryPolicy_HttpRetryEvent);
            }
            context.Spec_Http2Route_RetryPolicy_MaxRetry = this.Spec_Http2Route_RetryPolicy_MaxRetry;
            context.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit = this.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit;
            context.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value = this.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value;
            if (this.Spec_Http2Route_RetryPolicy_TcpRetryEvent != null)
            {
                context.Spec_Http2Route_RetryPolicy_TcpRetryEvent = new List<System.String>(this.Spec_Http2Route_RetryPolicy_TcpRetryEvent);
            }
            context.Spec_Http2Route_Timeout_Idle_Unit = this.Spec_Http2Route_Timeout_Idle_Unit;
            context.Spec_Http2Route_Timeout_Idle_Value = this.Spec_Http2Route_Timeout_Idle_Value;
            context.Spec_Http2Route_Timeout_PerRequest_Unit = this.Spec_Http2Route_Timeout_PerRequest_Unit;
            context.Spec_Http2Route_Timeout_PerRequest_Value = this.Spec_Http2Route_Timeout_PerRequest_Value;
            if (this.Spec_HttpRoute_Action_WeightedTarget != null)
            {
                context.Spec_HttpRoute_Action_WeightedTarget = new List<Amazon.AppMesh.Model.WeightedTarget>(this.Spec_HttpRoute_Action_WeightedTarget);
            }
            if (this.Spec_HttpRoute_Match_Header != null)
            {
                context.Spec_HttpRoute_Match_Header = new List<Amazon.AppMesh.Model.HttpRouteHeader>(this.Spec_HttpRoute_Match_Header);
            }
            context.Spec_HttpRoute_Match_Method = this.Spec_HttpRoute_Match_Method;
            context.Spec_HttpRoute_Match_Prefix = this.Spec_HttpRoute_Match_Prefix;
            context.Spec_HttpRoute_Match_Scheme = this.Spec_HttpRoute_Match_Scheme;
            if (this.Spec_HttpRoute_RetryPolicy_HttpRetryEvent != null)
            {
                context.Spec_HttpRoute_RetryPolicy_HttpRetryEvent = new List<System.String>(this.Spec_HttpRoute_RetryPolicy_HttpRetryEvent);
            }
            context.Spec_HttpRoute_RetryPolicy_MaxRetry = this.Spec_HttpRoute_RetryPolicy_MaxRetry;
            context.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit = this.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit;
            context.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value = this.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value;
            if (this.Spec_HttpRoute_RetryPolicy_TcpRetryEvent != null)
            {
                context.Spec_HttpRoute_RetryPolicy_TcpRetryEvent = new List<System.String>(this.Spec_HttpRoute_RetryPolicy_TcpRetryEvent);
            }
            context.Spec_HttpRoute_Timeout_Idle_Unit = this.Spec_HttpRoute_Timeout_Idle_Unit;
            context.Spec_HttpRoute_Timeout_Idle_Value = this.Spec_HttpRoute_Timeout_Idle_Value;
            context.Spec_HttpRoute_Timeout_PerRequest_Unit = this.Spec_HttpRoute_Timeout_PerRequest_Unit;
            context.Spec_HttpRoute_Timeout_PerRequest_Value = this.Spec_HttpRoute_Timeout_PerRequest_Value;
            context.Spec_Priority = this.Spec_Priority;
            if (this.Spec_TcpRoute_Action_WeightedTarget != null)
            {
                context.Spec_TcpRoute_Action_WeightedTarget = new List<Amazon.AppMesh.Model.WeightedTarget>(this.Spec_TcpRoute_Action_WeightedTarget);
            }
            context.Spec_TcpRoute_Timeout_Idle_Unit = this.Spec_TcpRoute_Timeout_Idle_Unit;
            context.Spec_TcpRoute_Timeout_Idle_Value = this.Spec_TcpRoute_Timeout_Idle_Value;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppMesh.Model.TagRef>(this.Tag);
            }
            context.VirtualRouterName = this.VirtualRouterName;
            #if MODULAR
            if (this.VirtualRouterName == null && ParameterWasBound(nameof(this.VirtualRouterName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualRouterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AppMesh.Model.CreateRouteRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.MeshOwner != null)
            {
                request.MeshOwner = cmdletContext.MeshOwner;
            }
            if (cmdletContext.RouteName != null)
            {
                request.RouteName = cmdletContext.RouteName;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.RouteSpec();
            System.Int32? requestSpec_spec_Priority = null;
            if (cmdletContext.Spec_Priority != null)
            {
                requestSpec_spec_Priority = cmdletContext.Spec_Priority.Value;
            }
            if (requestSpec_spec_Priority != null)
            {
                request.Spec.Priority = requestSpec_spec_Priority.Value;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.TcpRoute requestSpec_spec_TcpRoute = null;
            
             // populate TcpRoute
            var requestSpec_spec_TcpRouteIsNull = true;
            requestSpec_spec_TcpRoute = new Amazon.AppMesh.Model.TcpRoute();
            Amazon.AppMesh.Model.TcpRouteAction requestSpec_spec_TcpRoute_spec_TcpRoute_Action = null;
            
             // populate Action
            var requestSpec_spec_TcpRoute_spec_TcpRoute_ActionIsNull = true;
            requestSpec_spec_TcpRoute_spec_TcpRoute_Action = new Amazon.AppMesh.Model.TcpRouteAction();
            List<Amazon.AppMesh.Model.WeightedTarget> requestSpec_spec_TcpRoute_spec_TcpRoute_Action_spec_TcpRoute_Action_WeightedTarget = null;
            if (cmdletContext.Spec_TcpRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Action_spec_TcpRoute_Action_WeightedTarget = cmdletContext.Spec_TcpRoute_Action_WeightedTarget;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Action_spec_TcpRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Action.WeightedTargets = requestSpec_spec_TcpRoute_spec_TcpRoute_Action_spec_TcpRoute_Action_WeightedTarget;
                requestSpec_spec_TcpRoute_spec_TcpRoute_ActionIsNull = false;
            }
             // determine if requestSpec_spec_TcpRoute_spec_TcpRoute_Action should be set to null
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_ActionIsNull)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Action = null;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Action != null)
            {
                requestSpec_spec_TcpRoute.Action = requestSpec_spec_TcpRoute_spec_TcpRoute_Action;
                requestSpec_spec_TcpRouteIsNull = false;
            }
            Amazon.AppMesh.Model.TcpTimeout requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout = null;
            
             // populate Timeout
            var requestSpec_spec_TcpRoute_spec_TcpRoute_TimeoutIsNull = true;
            requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout = new Amazon.AppMesh.Model.TcpTimeout();
            Amazon.AppMesh.Model.Duration requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle = null;
            
             // populate Idle
            var requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_IdleIsNull = true;
            requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Unit = null;
            if (cmdletContext.Spec_TcpRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Unit = cmdletContext.Spec_TcpRoute_Timeout_Idle_Unit;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle.Unit = requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Unit;
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_IdleIsNull = false;
            }
            System.Int64? requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Value = null;
            if (cmdletContext.Spec_TcpRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Value = cmdletContext.Spec_TcpRoute_Timeout_Idle_Value.Value;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle.Value = requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle_spec_TcpRoute_Timeout_Idle_Value.Value;
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_IdleIsNull = false;
            }
             // determine if requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle should be set to null
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_IdleIsNull)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle = null;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle != null)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout.Idle = requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout_spec_TcpRoute_Timeout_Idle;
                requestSpec_spec_TcpRoute_spec_TcpRoute_TimeoutIsNull = false;
            }
             // determine if requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout should be set to null
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_TimeoutIsNull)
            {
                requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout = null;
            }
            if (requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout != null)
            {
                requestSpec_spec_TcpRoute.Timeout = requestSpec_spec_TcpRoute_spec_TcpRoute_Timeout;
                requestSpec_spec_TcpRouteIsNull = false;
            }
             // determine if requestSpec_spec_TcpRoute should be set to null
            if (requestSpec_spec_TcpRouteIsNull)
            {
                requestSpec_spec_TcpRoute = null;
            }
            if (requestSpec_spec_TcpRoute != null)
            {
                request.Spec.TcpRoute = requestSpec_spec_TcpRoute;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.GrpcRoute requestSpec_spec_GrpcRoute = null;
            
             // populate GrpcRoute
            var requestSpec_spec_GrpcRouteIsNull = true;
            requestSpec_spec_GrpcRoute = new Amazon.AppMesh.Model.GrpcRoute();
            Amazon.AppMesh.Model.GrpcRouteAction requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action = null;
            
             // populate Action
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_ActionIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action = new Amazon.AppMesh.Model.GrpcRouteAction();
            List<Amazon.AppMesh.Model.WeightedTarget> requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_WeightedTarget = null;
            if (cmdletContext.Spec_GrpcRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_WeightedTarget = cmdletContext.Spec_GrpcRoute_Action_WeightedTarget;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action.WeightedTargets = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_WeightedTarget;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_ActionIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_ActionIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action != null)
            {
                requestSpec_spec_GrpcRoute.Action = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action;
                requestSpec_spec_GrpcRouteIsNull = false;
            }
            Amazon.AppMesh.Model.GrpcTimeout requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout = null;
            
             // populate Timeout
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_TimeoutIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout = new Amazon.AppMesh.Model.GrpcTimeout();
            Amazon.AppMesh.Model.Duration requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle = null;
            
             // populate Idle
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_IdleIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Unit = null;
            if (cmdletContext.Spec_GrpcRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Unit = cmdletContext.Spec_GrpcRoute_Timeout_Idle_Unit;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle.Unit = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Unit;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_IdleIsNull = false;
            }
            System.Int64? requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Value = null;
            if (cmdletContext.Spec_GrpcRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Value = cmdletContext.Spec_GrpcRoute_Timeout_Idle_Value.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle.Value = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle_spec_GrpcRoute_Timeout_Idle_Value.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_IdleIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_IdleIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout.Idle = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_Idle;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_TimeoutIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest = null;
            
             // populate PerRequest
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequestIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Unit = null;
            if (cmdletContext.Spec_GrpcRoute_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Unit = cmdletContext.Spec_GrpcRoute_Timeout_PerRequest_Unit;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest.Unit = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Unit;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequestIsNull = false;
            }
            System.Int64? requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Value = null;
            if (cmdletContext.Spec_GrpcRoute_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Value = cmdletContext.Spec_GrpcRoute_Timeout_PerRequest_Value.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest.Value = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest_spec_GrpcRoute_Timeout_PerRequest_Value.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequestIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequestIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout.PerRequest = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout_spec_GrpcRoute_Timeout_PerRequest;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_TimeoutIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_TimeoutIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout != null)
            {
                requestSpec_spec_GrpcRoute.Timeout = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Timeout;
                requestSpec_spec_GrpcRouteIsNull = false;
            }
            Amazon.AppMesh.Model.GrpcRouteMatch requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match = null;
            
             // populate Match
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match = new Amazon.AppMesh.Model.GrpcRouteMatch();
            List<Amazon.AppMesh.Model.GrpcRouteMetadata> requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata = null;
            if (cmdletContext.Match_Metadata != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata = cmdletContext.Match_Metadata;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.Metadata = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_MethodName = null;
            if (cmdletContext.Spec_GrpcRoute_Match_MethodName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_MethodName = cmdletContext.Spec_GrpcRoute_Match_MethodName;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_MethodName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.MethodName = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_MethodName;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_ServiceName = null;
            if (cmdletContext.Match_ServiceName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_ServiceName = cmdletContext.Match_ServiceName;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_ServiceName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.ServiceName = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_ServiceName;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match != null)
            {
                requestSpec_spec_GrpcRoute.Match = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match;
                requestSpec_spec_GrpcRouteIsNull = false;
            }
            Amazon.AppMesh.Model.GrpcRetryPolicy requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy = null;
            
             // populate RetryPolicy
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy = new Amazon.AppMesh.Model.GrpcRetryPolicy();
            List<System.String> requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_retryPolicy_GrpcRetryEvent = null;
            if (cmdletContext.RetryPolicy_GrpcRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_retryPolicy_GrpcRetryEvent = cmdletContext.RetryPolicy_GrpcRetryEvent;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_retryPolicy_GrpcRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy.GrpcRetryEvents = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_retryPolicy_GrpcRetryEvent;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = false;
            }
            List<System.String> requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_HttpRetryEvent = null;
            if (cmdletContext.Spec_GrpcRoute_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_HttpRetryEvent = cmdletContext.Spec_GrpcRoute_RetryPolicy_HttpRetryEvent;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy.HttpRetryEvents = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_HttpRetryEvent;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = false;
            }
            System.Int64? requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_MaxRetry = null;
            if (cmdletContext.Spec_GrpcRoute_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_MaxRetry = cmdletContext.Spec_GrpcRoute_RetryPolicy_MaxRetry.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy.MaxRetries = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_MaxRetry.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = false;
            }
            List<System.String> requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_TcpRetryEvent = null;
            if (cmdletContext.Spec_GrpcRoute_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_TcpRetryEvent = cmdletContext.Spec_GrpcRoute_RetryPolicy_TcpRetryEvent;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy.TcpRetryEvents = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_TcpRetryEvent;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout = null;
            
             // populate PerRetryTimeout
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeoutIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit = null;
            if (cmdletContext.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit = cmdletContext.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout.Unit = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
            System.Int64? requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value = null;
            if (cmdletContext.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value = cmdletContext.Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout.Value = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeoutIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy.PerRetryTimeout = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy_spec_GrpcRoute_RetryPolicy_PerRetryTimeout;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicyIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy != null)
            {
                requestSpec_spec_GrpcRoute.RetryPolicy = requestSpec_spec_GrpcRoute_spec_GrpcRoute_RetryPolicy;
                requestSpec_spec_GrpcRouteIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute should be set to null
            if (requestSpec_spec_GrpcRouteIsNull)
            {
                requestSpec_spec_GrpcRoute = null;
            }
            if (requestSpec_spec_GrpcRoute != null)
            {
                request.Spec.GrpcRoute = requestSpec_spec_GrpcRoute;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRoute requestSpec_spec_Http2Route = null;
            
             // populate Http2Route
            var requestSpec_spec_Http2RouteIsNull = true;
            requestSpec_spec_Http2Route = new Amazon.AppMesh.Model.HttpRoute();
            Amazon.AppMesh.Model.HttpRouteAction requestSpec_spec_Http2Route_spec_Http2Route_Action = null;
            
             // populate Action
            var requestSpec_spec_Http2Route_spec_Http2Route_ActionIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action = new Amazon.AppMesh.Model.HttpRouteAction();
            List<Amazon.AppMesh.Model.WeightedTarget> requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_WeightedTarget = null;
            if (cmdletContext.Spec_Http2Route_Action_WeightedTarget != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_WeightedTarget = cmdletContext.Spec_Http2Route_Action_WeightedTarget;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_WeightedTarget != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action.WeightedTargets = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_WeightedTarget;
                requestSpec_spec_Http2Route_spec_Http2Route_ActionIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_ActionIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action != null)
            {
                requestSpec_spec_Http2Route.Action = requestSpec_spec_Http2Route_spec_Http2Route_Action;
                requestSpec_spec_Http2RouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpTimeout requestSpec_spec_Http2Route_spec_Http2Route_Timeout = null;
            
             // populate Timeout
            var requestSpec_spec_Http2Route_spec_Http2Route_TimeoutIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Timeout = new Amazon.AppMesh.Model.HttpTimeout();
            Amazon.AppMesh.Model.Duration requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle = null;
            
             // populate Idle
            var requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_IdleIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Unit = null;
            if (cmdletContext.Spec_Http2Route_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Unit = cmdletContext.Spec_Http2Route_Timeout_Idle_Unit;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle.Unit = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Unit;
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_IdleIsNull = false;
            }
            System.Int64? requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Value = null;
            if (cmdletContext.Spec_Http2Route_Timeout_Idle_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Value = cmdletContext.Spec_Http2Route_Timeout_Idle_Value.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle.Value = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle_spec_Http2Route_Timeout_Idle_Value.Value;
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_IdleIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_IdleIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout.Idle = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_Idle;
                requestSpec_spec_Http2Route_spec_Http2Route_TimeoutIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest = null;
            
             // populate PerRequest
            var requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequestIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Unit = null;
            if (cmdletContext.Spec_Http2Route_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Unit = cmdletContext.Spec_Http2Route_Timeout_PerRequest_Unit;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest.Unit = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Unit;
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequestIsNull = false;
            }
            System.Int64? requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Value = null;
            if (cmdletContext.Spec_Http2Route_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Value = cmdletContext.Spec_Http2Route_Timeout_PerRequest_Value.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest.Value = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest_spec_Http2Route_Timeout_PerRequest_Value.Value;
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequestIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequestIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout.PerRequest = requestSpec_spec_Http2Route_spec_Http2Route_Timeout_spec_Http2Route_Timeout_PerRequest;
                requestSpec_spec_Http2Route_spec_Http2Route_TimeoutIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Timeout should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_TimeoutIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Timeout = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Timeout != null)
            {
                requestSpec_spec_Http2Route.Timeout = requestSpec_spec_Http2Route_spec_Http2Route_Timeout;
                requestSpec_spec_Http2RouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRouteMatch requestSpec_spec_Http2Route_spec_Http2Route_Match = null;
            
             // populate Match
            var requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Match = new Amazon.AppMesh.Model.HttpRouteMatch();
            List<Amazon.AppMesh.Model.HttpRouteHeader> requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Header = null;
            if (cmdletContext.Spec_Http2Route_Match_Header != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Header = cmdletContext.Spec_Http2Route_Match_Header;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Header != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Headers = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Header;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
            Amazon.AppMesh.HttpMethod requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Method = null;
            if (cmdletContext.Spec_Http2Route_Match_Method != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Method = cmdletContext.Spec_Http2Route_Match_Method;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Method != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Method = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Method;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Prefix = null;
            if (cmdletContext.Spec_Http2Route_Match_Prefix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Prefix = cmdletContext.Spec_Http2Route_Match_Prefix;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Prefix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Prefix = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Prefix;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
            Amazon.AppMesh.HttpScheme requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Scheme = null;
            if (cmdletContext.Spec_Http2Route_Match_Scheme != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Scheme = cmdletContext.Spec_Http2Route_Match_Scheme;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Scheme != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Scheme = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Scheme;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Match should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match != null)
            {
                requestSpec_spec_Http2Route.Match = requestSpec_spec_Http2Route_spec_Http2Route_Match;
                requestSpec_spec_Http2RouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRetryPolicy requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy = null;
            
             // populate RetryPolicy
            var requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy = new Amazon.AppMesh.Model.HttpRetryPolicy();
            List<System.String> requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_HttpRetryEvent = null;
            if (cmdletContext.Spec_Http2Route_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_HttpRetryEvent = cmdletContext.Spec_Http2Route_RetryPolicy_HttpRetryEvent;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy.HttpRetryEvents = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_HttpRetryEvent;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull = false;
            }
            System.Int64? requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_MaxRetry = null;
            if (cmdletContext.Spec_Http2Route_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_MaxRetry = cmdletContext.Spec_Http2Route_RetryPolicy_MaxRetry.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy.MaxRetries = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_MaxRetry.Value;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull = false;
            }
            List<System.String> requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_TcpRetryEvent = null;
            if (cmdletContext.Spec_Http2Route_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_TcpRetryEvent = cmdletContext.Spec_Http2Route_RetryPolicy_TcpRetryEvent;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy.TcpRetryEvents = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_TcpRetryEvent;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout = null;
            
             // populate PerRetryTimeout
            var requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeoutIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit = null;
            if (cmdletContext.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit = cmdletContext.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout.Unit = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
            System.Int64? requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Value = null;
            if (cmdletContext.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Value = cmdletContext.Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout.Value = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout_spec_Http2Route_RetryPolicy_PerRetryTimeout_Value.Value;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeoutIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy.PerRetryTimeout = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy_spec_Http2Route_RetryPolicy_PerRetryTimeout;
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicyIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy != null)
            {
                requestSpec_spec_Http2Route.RetryPolicy = requestSpec_spec_Http2Route_spec_Http2Route_RetryPolicy;
                requestSpec_spec_Http2RouteIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route should be set to null
            if (requestSpec_spec_Http2RouteIsNull)
            {
                requestSpec_spec_Http2Route = null;
            }
            if (requestSpec_spec_Http2Route != null)
            {
                request.Spec.Http2Route = requestSpec_spec_Http2Route;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRoute requestSpec_spec_HttpRoute = null;
            
             // populate HttpRoute
            var requestSpec_spec_HttpRouteIsNull = true;
            requestSpec_spec_HttpRoute = new Amazon.AppMesh.Model.HttpRoute();
            Amazon.AppMesh.Model.HttpRouteAction requestSpec_spec_HttpRoute_spec_HttpRoute_Action = null;
            
             // populate Action
            var requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action = new Amazon.AppMesh.Model.HttpRouteAction();
            List<Amazon.AppMesh.Model.WeightedTarget> requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_WeightedTarget = null;
            if (cmdletContext.Spec_HttpRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_WeightedTarget = cmdletContext.Spec_HttpRoute_Action_WeightedTarget;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_WeightedTarget != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action.WeightedTargets = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_WeightedTarget;
                requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action != null)
            {
                requestSpec_spec_HttpRoute.Action = requestSpec_spec_HttpRoute_spec_HttpRoute_Action;
                requestSpec_spec_HttpRouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpTimeout requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout = null;
            
             // populate Timeout
            var requestSpec_spec_HttpRoute_spec_HttpRoute_TimeoutIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout = new Amazon.AppMesh.Model.HttpTimeout();
            Amazon.AppMesh.Model.Duration requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle = null;
            
             // populate Idle
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_IdleIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Unit = null;
            if (cmdletContext.Spec_HttpRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Unit = cmdletContext.Spec_HttpRoute_Timeout_Idle_Unit;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle.Unit = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Unit;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_IdleIsNull = false;
            }
            System.Int64? requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Value = null;
            if (cmdletContext.Spec_HttpRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Value = cmdletContext.Spec_HttpRoute_Timeout_Idle_Value.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle.Value = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle_spec_HttpRoute_Timeout_Idle_Value.Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_IdleIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_IdleIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout.Idle = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_Idle;
                requestSpec_spec_HttpRoute_spec_HttpRoute_TimeoutIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest = null;
            
             // populate PerRequest
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequestIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Unit = null;
            if (cmdletContext.Spec_HttpRoute_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Unit = cmdletContext.Spec_HttpRoute_Timeout_PerRequest_Unit;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest.Unit = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Unit;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequestIsNull = false;
            }
            System.Int64? requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Value = null;
            if (cmdletContext.Spec_HttpRoute_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Value = cmdletContext.Spec_HttpRoute_Timeout_PerRequest_Value.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest.Value = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest_spec_HttpRoute_Timeout_PerRequest_Value.Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequestIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequestIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout.PerRequest = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout_spec_HttpRoute_Timeout_PerRequest;
                requestSpec_spec_HttpRoute_spec_HttpRoute_TimeoutIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_TimeoutIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout != null)
            {
                requestSpec_spec_HttpRoute.Timeout = requestSpec_spec_HttpRoute_spec_HttpRoute_Timeout;
                requestSpec_spec_HttpRouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRouteMatch requestSpec_spec_HttpRoute_spec_HttpRoute_Match = null;
            
             // populate Match
            var requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Match = new Amazon.AppMesh.Model.HttpRouteMatch();
            List<Amazon.AppMesh.Model.HttpRouteHeader> requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Header = null;
            if (cmdletContext.Spec_HttpRoute_Match_Header != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Header = cmdletContext.Spec_HttpRoute_Match_Header;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Header != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Headers = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Header;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
            Amazon.AppMesh.HttpMethod requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Method = null;
            if (cmdletContext.Spec_HttpRoute_Match_Method != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Method = cmdletContext.Spec_HttpRoute_Match_Method;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Method != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Method = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Method;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Prefix = null;
            if (cmdletContext.Spec_HttpRoute_Match_Prefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Prefix = cmdletContext.Spec_HttpRoute_Match_Prefix;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Prefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Prefix = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Prefix;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
            Amazon.AppMesh.HttpScheme requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Scheme = null;
            if (cmdletContext.Spec_HttpRoute_Match_Scheme != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Scheme = cmdletContext.Spec_HttpRoute_Match_Scheme;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Scheme != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Scheme = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Scheme;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Match should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match != null)
            {
                requestSpec_spec_HttpRoute.Match = requestSpec_spec_HttpRoute_spec_HttpRoute_Match;
                requestSpec_spec_HttpRouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRetryPolicy requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy = null;
            
             // populate RetryPolicy
            var requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy = new Amazon.AppMesh.Model.HttpRetryPolicy();
            List<System.String> requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_HttpRetryEvent = null;
            if (cmdletContext.Spec_HttpRoute_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_HttpRetryEvent = cmdletContext.Spec_HttpRoute_RetryPolicy_HttpRetryEvent;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_HttpRetryEvent != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy.HttpRetryEvents = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_HttpRetryEvent;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull = false;
            }
            System.Int64? requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_MaxRetry = null;
            if (cmdletContext.Spec_HttpRoute_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_MaxRetry = cmdletContext.Spec_HttpRoute_RetryPolicy_MaxRetry.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_MaxRetry != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy.MaxRetries = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_MaxRetry.Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull = false;
            }
            List<System.String> requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_TcpRetryEvent = null;
            if (cmdletContext.Spec_HttpRoute_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_TcpRetryEvent = cmdletContext.Spec_HttpRoute_RetryPolicy_TcpRetryEvent;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_TcpRetryEvent != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy.TcpRetryEvents = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_TcpRetryEvent;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull = false;
            }
            Amazon.AppMesh.Model.Duration requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout = null;
            
             // populate PerRetryTimeout
            var requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeoutIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout = new Amazon.AppMesh.Model.Duration();
            Amazon.AppMesh.DurationUnit requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit = null;
            if (cmdletContext.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit = cmdletContext.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout.Unit = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
            System.Int64? requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value = null;
            if (cmdletContext.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value = cmdletContext.Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout.Value = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout_spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value.Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeoutIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeoutIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy.PerRetryTimeout = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy_spec_HttpRoute_RetryPolicy_PerRetryTimeout;
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicyIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy != null)
            {
                requestSpec_spec_HttpRoute.RetryPolicy = requestSpec_spec_HttpRoute_spec_HttpRoute_RetryPolicy;
                requestSpec_spec_HttpRouteIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute should be set to null
            if (requestSpec_spec_HttpRouteIsNull)
            {
                requestSpec_spec_HttpRoute = null;
            }
            if (requestSpec_spec_HttpRoute != null)
            {
                request.Spec.HttpRoute = requestSpec_spec_HttpRoute;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VirtualRouterName != null)
            {
                request.VirtualRouterName = cmdletContext.VirtualRouterName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AppMesh.Model.CreateRouteResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.CreateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "CreateRoute");
            try
            {
                #if DESKTOP
                return client.CreateRoute(request);
                #elif CORECLR
                return client.CreateRouteAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String MeshName { get; set; }
            public System.String MeshOwner { get; set; }
            public System.String RouteName { get; set; }
            public List<Amazon.AppMesh.Model.WeightedTarget> Spec_GrpcRoute_Action_WeightedTarget { get; set; }
            public List<Amazon.AppMesh.Model.GrpcRouteMetadata> Match_Metadata { get; set; }
            public System.String Spec_GrpcRoute_Match_MethodName { get; set; }
            public System.String Match_ServiceName { get; set; }
            public List<System.String> RetryPolicy_GrpcRetryEvent { get; set; }
            public List<System.String> Spec_GrpcRoute_RetryPolicy_HttpRetryEvent { get; set; }
            public System.Int64? Spec_GrpcRoute_RetryPolicy_MaxRetry { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit { get; set; }
            public System.Int64? Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value { get; set; }
            public List<System.String> Spec_GrpcRoute_RetryPolicy_TcpRetryEvent { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_Timeout_Idle_Unit { get; set; }
            public System.Int64? Spec_GrpcRoute_Timeout_Idle_Value { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_GrpcRoute_Timeout_PerRequest_Unit { get; set; }
            public System.Int64? Spec_GrpcRoute_Timeout_PerRequest_Value { get; set; }
            public List<Amazon.AppMesh.Model.WeightedTarget> Spec_Http2Route_Action_WeightedTarget { get; set; }
            public List<Amazon.AppMesh.Model.HttpRouteHeader> Spec_Http2Route_Match_Header { get; set; }
            public Amazon.AppMesh.HttpMethod Spec_Http2Route_Match_Method { get; set; }
            public System.String Spec_Http2Route_Match_Prefix { get; set; }
            public Amazon.AppMesh.HttpScheme Spec_Http2Route_Match_Scheme { get; set; }
            public List<System.String> Spec_Http2Route_RetryPolicy_HttpRetryEvent { get; set; }
            public System.Int64? Spec_Http2Route_RetryPolicy_MaxRetry { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit { get; set; }
            public System.Int64? Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value { get; set; }
            public List<System.String> Spec_Http2Route_RetryPolicy_TcpRetryEvent { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_Http2Route_Timeout_Idle_Unit { get; set; }
            public System.Int64? Spec_Http2Route_Timeout_Idle_Value { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_Http2Route_Timeout_PerRequest_Unit { get; set; }
            public System.Int64? Spec_Http2Route_Timeout_PerRequest_Value { get; set; }
            public List<Amazon.AppMesh.Model.WeightedTarget> Spec_HttpRoute_Action_WeightedTarget { get; set; }
            public List<Amazon.AppMesh.Model.HttpRouteHeader> Spec_HttpRoute_Match_Header { get; set; }
            public Amazon.AppMesh.HttpMethod Spec_HttpRoute_Match_Method { get; set; }
            public System.String Spec_HttpRoute_Match_Prefix { get; set; }
            public Amazon.AppMesh.HttpScheme Spec_HttpRoute_Match_Scheme { get; set; }
            public List<System.String> Spec_HttpRoute_RetryPolicy_HttpRetryEvent { get; set; }
            public System.Int64? Spec_HttpRoute_RetryPolicy_MaxRetry { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit { get; set; }
            public System.Int64? Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value { get; set; }
            public List<System.String> Spec_HttpRoute_RetryPolicy_TcpRetryEvent { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_HttpRoute_Timeout_Idle_Unit { get; set; }
            public System.Int64? Spec_HttpRoute_Timeout_Idle_Value { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_HttpRoute_Timeout_PerRequest_Unit { get; set; }
            public System.Int64? Spec_HttpRoute_Timeout_PerRequest_Value { get; set; }
            public System.Int32? Spec_Priority { get; set; }
            public List<Amazon.AppMesh.Model.WeightedTarget> Spec_TcpRoute_Action_WeightedTarget { get; set; }
            public Amazon.AppMesh.DurationUnit Spec_TcpRoute_Timeout_Idle_Unit { get; set; }
            public System.Int64? Spec_TcpRoute_Timeout_Idle_Value { get; set; }
            public List<Amazon.AppMesh.Model.TagRef> Tag { get; set; }
            public System.String VirtualRouterName { get; set; }
            public System.Func<Amazon.AppMesh.Model.CreateRouteResponse, NewAMSHRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Route;
        }
        
    }
}
