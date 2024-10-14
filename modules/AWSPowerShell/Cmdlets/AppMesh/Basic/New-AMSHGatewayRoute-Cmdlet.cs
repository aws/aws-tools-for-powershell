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
    /// Creates a gateway route.
    /// 
    ///  
    /// <para>
    /// A gateway route is attached to a virtual gateway and routes traffic to an existing
    /// virtual service. If a route matches a request, it can distribute traffic to a target
    /// virtual service.
    /// </para><para>
    /// For more information about gateway routes, see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/gateway-routes.html">Gateway
    /// routes</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMSHGatewayRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.GatewayRouteData")]
    [AWSCmdlet("Calls the AWS App Mesh CreateGatewayRoute API operation.", Operation = new[] {"CreateGatewayRoute"}, SelectReturnType = typeof(Amazon.AppMesh.Model.CreateGatewayRouteResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.GatewayRouteData or Amazon.AppMesh.Model.CreateGatewayRouteResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.GatewayRouteData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateGatewayRouteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMSHGatewayRouteCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix
        /// <summary>
        /// <para>
        /// <para>The default prefix used to replace the incoming route prefix when rewritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DefaultGatewayRouteRewrite")]
        public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix
        /// <summary>
        /// <para>
        /// <para>The default prefix used to replace the incoming route prefix when rewritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultPrefix")]
        [AWSConstantClassSource("Amazon.AppMesh.DefaultGatewayRouteRewrite")]
        public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname
        /// <summary>
        /// <para>
        /// <para>The default target host name to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DefaultGatewayRouteRewrite")]
        public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname
        /// <summary>
        /// <para>
        /// <para>The default target host name to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.DefaultGatewayRouteRewrite")]
        public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname
        /// <summary>
        /// <para>
        /// <para>The default target host name to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultTargetHostname")]
        [AWSConstantClassSource("Amazon.AppMesh.DefaultGatewayRouteRewrite")]
        public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Match_Hostname_Exact
        /// <summary>
        /// <para>
        /// <para>The exact host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_GrpcRoute_Match_Hostname_Exact { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_Rewrite_Path_Exact
        /// <summary>
        /// <para>
        /// <para>The exact path to rewrite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rewrite_Http2_Path_Exact")]
        public System.String Spec_Http2Route_Action_Rewrite_Path_Exact { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Hostname_Exact
        /// <summary>
        /// <para>
        /// <para>The exact host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Match_Hostname_Exact { get; set; }
        #endregion
        
        #region Parameter Path_Exact
        /// <summary>
        /// <para>
        /// <para>The exact path to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_Match_Path_Exact")]
        public System.String Path_Exact { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Rewrite_Path_Exact
        /// <summary>
        /// <para>
        /// <para>The exact path to rewrite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rewrite_Path_Exact")]
        public System.String Spec_HttpRoute_Action_Rewrite_Path_Exact { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Hostname_Exact
        /// <summary>
        /// <para>
        /// <para>The exact host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hostname_Exact")]
        public System.String Spec_HttpRoute_Match_Hostname_Exact { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Path_Exact
        /// <summary>
        /// <para>
        /// <para>The exact path to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Path_Exact")]
        public System.String Spec_HttpRoute_Match_Path_Exact { get; set; }
        #endregion
        
        #region Parameter GatewayRouteName
        /// <summary>
        /// <para>
        /// <para>The name to use for the gateway route.</para>
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
        public System.String GatewayRouteName { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Headers
        /// <summary>
        /// <para>
        /// <para>The client request headers to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppMesh.Model.HttpGatewayRouteHeader[] Spec_Http2Route_Match_Headers { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Headers
        /// <summary>
        /// <para>
        /// <para>The client request headers to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Headers")]
        public Amazon.AppMesh.Model.HttpGatewayRouteHeader[] Spec_HttpRoute_Match_Headers { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to create the gateway route in.</para>
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
        /// <para>The Amazon Web Services IAM account ID of the service mesh owner. If the account ID
        /// is not your own, then the account that you specify must share the mesh with your account
        /// before you can create the resource in the service mesh. For more information about
        /// mesh sharing, see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/sharing.html">Working
        /// with shared meshes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshOwner { get; set; }
        #endregion
        
        #region Parameter Match_Metadata
        /// <summary>
        /// <para>
        /// <para>The gateway route metadata to be matched on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_Match_Metadata")]
        public Amazon.AppMesh.Model.GrpcGatewayRouteMetadata[] Match_Metadata { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Method
        /// <summary>
        /// <para>
        /// <para>The method to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppMesh.HttpMethod")]
        public Amazon.AppMesh.HttpMethod Spec_Http2Route_Match_Method { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Method
        /// <summary>
        /// <para>
        /// <para>The method to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_Method")]
        [AWSConstantClassSource("Amazon.AppMesh.HttpMethod")]
        public Amazon.AppMesh.HttpMethod Spec_HttpRoute_Match_Method { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Action_Target_Port
        /// <summary>
        /// <para>
        /// <para>The port number of the gateway route target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_GrpcRoute_Action_Target_Port { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Match_Port
        /// <summary>
        /// <para>
        /// <para>The gateway route port to be matched on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_GrpcRoute_Match_Port { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_Target_Port
        /// <summary>
        /// <para>
        /// <para>The port number of the gateway route target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_Http2Route_Action_Target_Port { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Port
        /// <summary>
        /// <para>
        /// <para>The port number to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_Http2Route_Match_Port { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Target_Port
        /// <summary>
        /// <para>
        /// <para>The port number of the gateway route target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_HttpRoute_Action_Target_Port { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Port
        /// <summary>
        /// <para>
        /// <para>The port number to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_HttpRoute_Match_Port { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies the path to match requests with. This parameter must always start with <c>/</c>,
        /// which by itself matches all requests to the virtual service name. You can also match
        /// for path-based routing of requests. For example, if your virtual service name is <c>my-service.local</c>
        /// and you want the route to match requests to <c>my-service.local/metrics</c>, your
        /// prefix should be <c>/metrics</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Match_Prefix { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies the path to match requests with. This parameter must always start with <c>/</c>,
        /// which by itself matches all requests to the virtual service name. You can also match
        /// for path-based routing of requests. For example, if your virtual service name is <c>my-service.local</c>
        /// and you want the route to match requests to <c>my-service.local/metrics</c>, your
        /// prefix should be <c>/metrics</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_HttpRoute_Match_Prefix { get; set; }
        #endregion
        
        #region Parameter Spec_Priority
        /// <summary>
        /// <para>
        /// <para>The ordering of the gateway routes spec.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Spec_Priority { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_QueryParameters
        /// <summary>
        /// <para>
        /// <para>The query parameter to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppMesh.Model.HttpQueryParameter[] Spec_Http2Route_Match_QueryParameters { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_QueryParameters
        /// <summary>
        /// <para>
        /// <para>The query parameter to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_QueryParameters")]
        public Amazon.AppMesh.Model.HttpQueryParameter[] Spec_HttpRoute_Match_QueryParameters { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Path_Regex
        /// <summary>
        /// <para>
        /// <para>The regex used to match the path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Match_Path_Regex { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Path_Regex
        /// <summary>
        /// <para>
        /// <para>The regex used to match the path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Path_Regex")]
        public System.String Spec_HttpRoute_Match_Path_Regex { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Match_ServiceName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name for the service to match from the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_GrpcRoute_Match_ServiceName { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Match_Hostname_Suffix
        /// <summary>
        /// <para>
        /// <para>The specified ending characters of the host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_GrpcRoute_Match_Hostname_Suffix { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Match_Hostname_Suffix
        /// <summary>
        /// <para>
        /// <para>The specified ending characters of the host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Match_Hostname_Suffix { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Match_Hostname_Suffix
        /// <summary>
        /// <para>
        /// <para>The specified ending characters of the host name to match on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Hostname_Suffix")]
        public System.String Spec_HttpRoute_Match_Hostname_Suffix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you can apply to the gateway route to assist with categorization
        /// and organization. Each tag consists of a key and an optional value, both of which
        /// you define. Tag keys can have a maximum character length of 128 characters, and tag
        /// values can have a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppMesh.Model.TagRef[] Tag { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_Rewrite_Prefix_Value
        /// <summary>
        /// <para>
        /// <para>The value used to replace the incoming route prefix when rewritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_Http2Route_Action_Rewrite_Prefix_Value { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Rewrite_Prefix_Value
        /// <summary>
        /// <para>
        /// <para>The value used to replace the incoming route prefix when rewritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Prefix_Value")]
        public System.String Spec_HttpRoute_Action_Rewrite_Prefix_Value { get; set; }
        #endregion
        
        #region Parameter VirtualGatewayName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual gateway to associate the gateway route with. If the virtual
        /// gateway is in a shared mesh, then you must be the owner of the virtual gateway resource.</para>
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
        public System.String VirtualGatewayName { get; set; }
        #endregion
        
        #region Parameter Spec_GrpcRoute_Action_Target_VirtualService
        /// <summary>
        /// <para>
        /// <para>The name of the virtual service that traffic is routed to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_GrpcRoute_Action_Target_VirtualService_VirtualServiceName")]
        public System.String Spec_GrpcRoute_Action_Target_VirtualService { get; set; }
        #endregion
        
        #region Parameter Spec_Http2Route_Action_Target_VirtualService
        /// <summary>
        /// <para>
        /// <para>The name of the virtual service that traffic is routed to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Http2Route_Action_Target_VirtualService_VirtualServiceName")]
        public System.String Spec_Http2Route_Action_Target_VirtualService { get; set; }
        #endregion
        
        #region Parameter Spec_HttpRoute_Action_Target_VirtualService
        /// <summary>
        /// <para>
        /// <para>The name of the virtual service that traffic is routed to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_HttpRoute_Action_Target_VirtualService_VirtualServiceName")]
        public System.String Spec_HttpRoute_Action_Target_VirtualService { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayRoute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.CreateGatewayRouteResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.CreateGatewayRouteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayRoute";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayRouteName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayRouteName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayRouteName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayRouteName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHGatewayRoute (CreateGatewayRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.CreateGatewayRouteResponse, NewAMSHGatewayRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayRouteName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.GatewayRouteName = this.GatewayRouteName;
            #if MODULAR
            if (this.GatewayRouteName == null && ParameterWasBound(nameof(this.GatewayRouteName)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayRouteName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshOwner = this.MeshOwner;
            context.Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname = this.Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
            context.Spec_GrpcRoute_Action_Target_Port = this.Spec_GrpcRoute_Action_Target_Port;
            context.Spec_GrpcRoute_Action_Target_VirtualService = this.Spec_GrpcRoute_Action_Target_VirtualService;
            context.Spec_GrpcRoute_Match_Hostname_Exact = this.Spec_GrpcRoute_Match_Hostname_Exact;
            context.Spec_GrpcRoute_Match_Hostname_Suffix = this.Spec_GrpcRoute_Match_Hostname_Suffix;
            if (this.Match_Metadata != null)
            {
                context.Match_Metadata = new List<Amazon.AppMesh.Model.GrpcGatewayRouteMetadata>(this.Match_Metadata);
            }
            context.Spec_GrpcRoute_Match_Port = this.Spec_GrpcRoute_Match_Port;
            context.Spec_GrpcRoute_Match_ServiceName = this.Spec_GrpcRoute_Match_ServiceName;
            context.Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname = this.Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname;
            context.Spec_Http2Route_Action_Rewrite_Path_Exact = this.Spec_Http2Route_Action_Rewrite_Path_Exact;
            context.Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix = this.Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix;
            context.Spec_Http2Route_Action_Rewrite_Prefix_Value = this.Spec_Http2Route_Action_Rewrite_Prefix_Value;
            context.Spec_Http2Route_Action_Target_Port = this.Spec_Http2Route_Action_Target_Port;
            context.Spec_Http2Route_Action_Target_VirtualService = this.Spec_Http2Route_Action_Target_VirtualService;
            if (this.Spec_Http2Route_Match_Headers != null)
            {
                context.Spec_Http2Route_Match_Headers = new List<Amazon.AppMesh.Model.HttpGatewayRouteHeader>(this.Spec_Http2Route_Match_Headers);
            }
            context.Spec_Http2Route_Match_Hostname_Exact = this.Spec_Http2Route_Match_Hostname_Exact;
            context.Spec_Http2Route_Match_Hostname_Suffix = this.Spec_Http2Route_Match_Hostname_Suffix;
            context.Spec_Http2Route_Match_Method = this.Spec_Http2Route_Match_Method;
            context.Path_Exact = this.Path_Exact;
            context.Spec_Http2Route_Match_Path_Regex = this.Spec_Http2Route_Match_Path_Regex;
            context.Spec_Http2Route_Match_Port = this.Spec_Http2Route_Match_Port;
            context.Spec_Http2Route_Match_Prefix = this.Spec_Http2Route_Match_Prefix;
            if (this.Spec_Http2Route_Match_QueryParameters != null)
            {
                context.Spec_Http2Route_Match_QueryParameters = new List<Amazon.AppMesh.Model.HttpQueryParameter>(this.Spec_Http2Route_Match_QueryParameters);
            }
            context.Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname = this.Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
            context.Spec_HttpRoute_Action_Rewrite_Path_Exact = this.Spec_HttpRoute_Action_Rewrite_Path_Exact;
            context.Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix = this.Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix;
            context.Spec_HttpRoute_Action_Rewrite_Prefix_Value = this.Spec_HttpRoute_Action_Rewrite_Prefix_Value;
            context.Spec_HttpRoute_Action_Target_Port = this.Spec_HttpRoute_Action_Target_Port;
            context.Spec_HttpRoute_Action_Target_VirtualService = this.Spec_HttpRoute_Action_Target_VirtualService;
            if (this.Spec_HttpRoute_Match_Headers != null)
            {
                context.Spec_HttpRoute_Match_Headers = new List<Amazon.AppMesh.Model.HttpGatewayRouteHeader>(this.Spec_HttpRoute_Match_Headers);
            }
            context.Spec_HttpRoute_Match_Hostname_Exact = this.Spec_HttpRoute_Match_Hostname_Exact;
            context.Spec_HttpRoute_Match_Hostname_Suffix = this.Spec_HttpRoute_Match_Hostname_Suffix;
            context.Spec_HttpRoute_Match_Method = this.Spec_HttpRoute_Match_Method;
            context.Spec_HttpRoute_Match_Path_Exact = this.Spec_HttpRoute_Match_Path_Exact;
            context.Spec_HttpRoute_Match_Path_Regex = this.Spec_HttpRoute_Match_Path_Regex;
            context.Spec_HttpRoute_Match_Port = this.Spec_HttpRoute_Match_Port;
            context.Spec_HttpRoute_Match_Prefix = this.Spec_HttpRoute_Match_Prefix;
            if (this.Spec_HttpRoute_Match_QueryParameters != null)
            {
                context.Spec_HttpRoute_Match_QueryParameters = new List<Amazon.AppMesh.Model.HttpQueryParameter>(this.Spec_HttpRoute_Match_QueryParameters);
            }
            context.Spec_Priority = this.Spec_Priority;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppMesh.Model.TagRef>(this.Tag);
            }
            context.VirtualGatewayName = this.VirtualGatewayName;
            #if MODULAR
            if (this.VirtualGatewayName == null && ParameterWasBound(nameof(this.VirtualGatewayName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualGatewayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppMesh.Model.CreateGatewayRouteRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GatewayRouteName != null)
            {
                request.GatewayRouteName = cmdletContext.GatewayRouteName;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.MeshOwner != null)
            {
                request.MeshOwner = cmdletContext.MeshOwner;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.GatewayRouteSpec();
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
            Amazon.AppMesh.Model.GrpcGatewayRoute requestSpec_spec_GrpcRoute = null;
            
             // populate GrpcRoute
            var requestSpec_spec_GrpcRouteIsNull = true;
            requestSpec_spec_GrpcRoute = new Amazon.AppMesh.Model.GrpcGatewayRoute();
            Amazon.AppMesh.Model.GrpcGatewayRouteAction requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action = null;
            
             // populate Action
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_ActionIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action = new Amazon.AppMesh.Model.GrpcGatewayRouteAction();
            Amazon.AppMesh.Model.GrpcGatewayRouteRewrite requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite = null;
            
             // populate Rewrite
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_RewriteIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite = new Amazon.AppMesh.Model.GrpcGatewayRouteRewrite();
            Amazon.AppMesh.Model.GatewayRouteHostnameRewrite requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_HostnameIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameRewrite();
            Amazon.AppMesh.DefaultGatewayRouteRewrite requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname_spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname = null;
            if (cmdletContext.Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname_spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname = cmdletContext.Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname_spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname.DefaultTargetHostname = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname_spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_HostnameIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite.Hostname = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite_spec_GrpcRoute_Action_Rewrite_Hostname;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_RewriteIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_RewriteIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action.Rewrite = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Rewrite;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_ActionIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteTarget requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target = null;
            
             // populate Target
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_TargetIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target = new Amazon.AppMesh.Model.GatewayRouteTarget();
            System.Int32? requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_Port = null;
            if (cmdletContext.Spec_GrpcRoute_Action_Target_Port != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_Port = cmdletContext.Spec_GrpcRoute_Action_Target_Port.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_Port != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target.Port = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_Port.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_TargetIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteVirtualService requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService = null;
            
             // populate VirtualService
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualServiceIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService = new Amazon.AppMesh.Model.GatewayRouteVirtualService();
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService_spec_GrpcRoute_Action_Target_VirtualService = null;
            if (cmdletContext.Spec_GrpcRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService_spec_GrpcRoute_Action_Target_VirtualService = cmdletContext.Spec_GrpcRoute_Action_Target_VirtualService;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService_spec_GrpcRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService.VirtualServiceName = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService_spec_GrpcRoute_Action_Target_VirtualService;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualServiceIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualServiceIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target.VirtualService = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target_spec_GrpcRoute_Action_Target_VirtualService;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_TargetIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_TargetIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action.Target = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Action_spec_GrpcRoute_Action_Target;
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
            Amazon.AppMesh.Model.GrpcGatewayRouteMatch requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match = null;
            
             // populate Match
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match = new Amazon.AppMesh.Model.GrpcGatewayRouteMatch();
            List<Amazon.AppMesh.Model.GrpcGatewayRouteMetadata> requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata = null;
            if (cmdletContext.Match_Metadata != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata = cmdletContext.Match_Metadata;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.Metadata = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_match_Metadata;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
            System.Int32? requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Port = null;
            if (cmdletContext.Spec_GrpcRoute_Match_Port != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Port = cmdletContext.Spec_GrpcRoute_Match_Port.Value;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Port != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.Port = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Port.Value;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_ServiceName = null;
            if (cmdletContext.Spec_GrpcRoute_Match_ServiceName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_ServiceName = cmdletContext.Spec_GrpcRoute_Match_ServiceName;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_ServiceName != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.ServiceName = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_ServiceName;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_MatchIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteHostnameMatch requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_HostnameIsNull = true;
            requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameMatch();
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Exact = null;
            if (cmdletContext.Spec_GrpcRoute_Match_Hostname_Exact != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Exact = cmdletContext.Spec_GrpcRoute_Match_Hostname_Exact;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Exact != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname.Exact = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Exact;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_HostnameIsNull = false;
            }
            System.String requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Suffix = null;
            if (cmdletContext.Spec_GrpcRoute_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Suffix = cmdletContext.Spec_GrpcRoute_Match_Hostname_Suffix;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname.Suffix = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname_spec_GrpcRoute_Match_Hostname_Suffix;
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname should be set to null
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_HostnameIsNull)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname = null;
            }
            if (requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname != null)
            {
                requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match.Hostname = requestSpec_spec_GrpcRoute_spec_GrpcRoute_Match_spec_GrpcRoute_Match_Hostname;
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
            Amazon.AppMesh.Model.HttpGatewayRoute requestSpec_spec_Http2Route = null;
            
             // populate Http2Route
            var requestSpec_spec_Http2RouteIsNull = true;
            requestSpec_spec_Http2Route = new Amazon.AppMesh.Model.HttpGatewayRoute();
            Amazon.AppMesh.Model.HttpGatewayRouteAction requestSpec_spec_Http2Route_spec_Http2Route_Action = null;
            
             // populate Action
            var requestSpec_spec_Http2Route_spec_Http2Route_ActionIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action = new Amazon.AppMesh.Model.HttpGatewayRouteAction();
            Amazon.AppMesh.Model.GatewayRouteTarget requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target = null;
            
             // populate Target
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_TargetIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target = new Amazon.AppMesh.Model.GatewayRouteTarget();
            System.Int32? requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_Port = null;
            if (cmdletContext.Spec_Http2Route_Action_Target_Port != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_Port = cmdletContext.Spec_Http2Route_Action_Target_Port.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_Port != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target.Port = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_Port.Value;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_TargetIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteVirtualService requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService = null;
            
             // populate VirtualService
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualServiceIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService = new Amazon.AppMesh.Model.GatewayRouteVirtualService();
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService_spec_Http2Route_Action_Target_VirtualService = null;
            if (cmdletContext.Spec_Http2Route_Action_Target_VirtualService != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService_spec_Http2Route_Action_Target_VirtualService = cmdletContext.Spec_Http2Route_Action_Target_VirtualService;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService_spec_Http2Route_Action_Target_VirtualService != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService.VirtualServiceName = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService_spec_Http2Route_Action_Target_VirtualService;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualServiceIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualServiceIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target.VirtualService = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target_spec_Http2Route_Action_Target_VirtualService;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_TargetIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_TargetIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action.Target = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Target;
                requestSpec_spec_Http2Route_spec_Http2Route_ActionIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRouteRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite = null;
            
             // populate Rewrite
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_RewriteIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite = new Amazon.AppMesh.Model.HttpGatewayRouteRewrite();
            Amazon.AppMesh.Model.GatewayRouteHostnameRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_HostnameIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameRewrite();
            Amazon.AppMesh.DefaultGatewayRouteRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname_spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname = null;
            if (cmdletContext.Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname_spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname = cmdletContext.Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname_spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname.DefaultTargetHostname = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname_spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_HostnameIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite.Hostname = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Hostname;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_RewriteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRoutePathRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path = null;
            
             // populate Path
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PathIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path = new Amazon.AppMesh.Model.HttpGatewayRoutePathRewrite();
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path_spec_Http2Route_Action_Rewrite_Path_Exact = null;
            if (cmdletContext.Spec_Http2Route_Action_Rewrite_Path_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path_spec_Http2Route_Action_Rewrite_Path_Exact = cmdletContext.Spec_Http2Route_Action_Rewrite_Path_Exact;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path_spec_Http2Route_Action_Rewrite_Path_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path.Exact = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path_spec_Http2Route_Action_Rewrite_Path_Exact;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PathIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PathIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite.Path = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Path;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_RewriteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRoutePrefixRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix = null;
            
             // populate Prefix
            var requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PrefixIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix = new Amazon.AppMesh.Model.HttpGatewayRoutePrefixRewrite();
            Amazon.AppMesh.DefaultGatewayRouteRewrite requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix = null;
            if (cmdletContext.Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix = cmdletContext.Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix.DefaultPrefix = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PrefixIsNull = false;
            }
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_Value = null;
            if (cmdletContext.Spec_Http2Route_Action_Rewrite_Prefix_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_Value = cmdletContext.Spec_Http2Route_Action_Rewrite_Prefix_Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_Value != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix.Value = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix_spec_Http2Route_Action_Rewrite_Prefix_Value;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PrefixIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_PrefixIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite.Prefix = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite_spec_Http2Route_Action_Rewrite_Prefix;
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_RewriteIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_RewriteIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Action.Rewrite = requestSpec_spec_Http2Route_spec_Http2Route_Action_spec_Http2Route_Action_Rewrite;
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
            Amazon.AppMesh.Model.HttpGatewayRouteMatch requestSpec_spec_Http2Route_spec_Http2Route_Match = null;
            
             // populate Match
            var requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Match = new Amazon.AppMesh.Model.HttpGatewayRouteMatch();
            List<Amazon.AppMesh.Model.HttpGatewayRouteHeader> requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Headers = null;
            if (cmdletContext.Spec_Http2Route_Match_Headers != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Headers = cmdletContext.Spec_Http2Route_Match_Headers;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Headers != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Headers = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Headers;
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
            System.Int32? requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Port = null;
            if (cmdletContext.Spec_Http2Route_Match_Port != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Port = cmdletContext.Spec_Http2Route_Match_Port.Value;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Port != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Port = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Port.Value;
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
            List<Amazon.AppMesh.Model.HttpQueryParameter> requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_QueryParameters = null;
            if (cmdletContext.Spec_Http2Route_Match_QueryParameters != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_QueryParameters = cmdletContext.Spec_Http2Route_Match_QueryParameters;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_QueryParameters != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.QueryParameters = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_QueryParameters;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteHostnameMatch requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_HostnameIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameMatch();
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Exact = null;
            if (cmdletContext.Spec_Http2Route_Match_Hostname_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Exact = cmdletContext.Spec_Http2Route_Match_Hostname_Exact;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname.Exact = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Exact;
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_HostnameIsNull = false;
            }
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Suffix = null;
            if (cmdletContext.Spec_Http2Route_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Suffix = cmdletContext.Spec_Http2Route_Match_Hostname_Suffix;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname.Suffix = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname_spec_Http2Route_Match_Hostname_Suffix;
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_HostnameIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Hostname = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Hostname;
                requestSpec_spec_Http2Route_spec_Http2Route_MatchIsNull = false;
            }
            Amazon.AppMesh.Model.HttpPathMatch requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path = null;
            
             // populate Path
            var requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_PathIsNull = true;
            requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path = new Amazon.AppMesh.Model.HttpPathMatch();
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_path_Exact = null;
            if (cmdletContext.Path_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_path_Exact = cmdletContext.Path_Exact;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_path_Exact != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path.Exact = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_path_Exact;
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_PathIsNull = false;
            }
            System.String requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_spec_Http2Route_Match_Path_Regex = null;
            if (cmdletContext.Spec_Http2Route_Match_Path_Regex != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_spec_Http2Route_Match_Path_Regex = cmdletContext.Spec_Http2Route_Match_Path_Regex;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_spec_Http2Route_Match_Path_Regex != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path.Regex = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path_spec_Http2Route_Match_Path_Regex;
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_PathIsNull = false;
            }
             // determine if requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path should be set to null
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_PathIsNull)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path = null;
            }
            if (requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path != null)
            {
                requestSpec_spec_Http2Route_spec_Http2Route_Match.Path = requestSpec_spec_Http2Route_spec_Http2Route_Match_spec_Http2Route_Match_Path;
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
            Amazon.AppMesh.Model.HttpGatewayRoute requestSpec_spec_HttpRoute = null;
            
             // populate HttpRoute
            var requestSpec_spec_HttpRouteIsNull = true;
            requestSpec_spec_HttpRoute = new Amazon.AppMesh.Model.HttpGatewayRoute();
            Amazon.AppMesh.Model.HttpGatewayRouteAction requestSpec_spec_HttpRoute_spec_HttpRoute_Action = null;
            
             // populate Action
            var requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action = new Amazon.AppMesh.Model.HttpGatewayRouteAction();
            Amazon.AppMesh.Model.GatewayRouteTarget requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target = null;
            
             // populate Target
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_TargetIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target = new Amazon.AppMesh.Model.GatewayRouteTarget();
            System.Int32? requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_Port = null;
            if (cmdletContext.Spec_HttpRoute_Action_Target_Port != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_Port = cmdletContext.Spec_HttpRoute_Action_Target_Port.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_Port != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target.Port = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_Port.Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_TargetIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteVirtualService requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService = null;
            
             // populate VirtualService
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualServiceIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService = new Amazon.AppMesh.Model.GatewayRouteVirtualService();
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService_spec_HttpRoute_Action_Target_VirtualService = null;
            if (cmdletContext.Spec_HttpRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService_spec_HttpRoute_Action_Target_VirtualService = cmdletContext.Spec_HttpRoute_Action_Target_VirtualService;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService_spec_HttpRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService.VirtualServiceName = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService_spec_HttpRoute_Action_Target_VirtualService;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualServiceIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualServiceIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target.VirtualService = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target_spec_HttpRoute_Action_Target_VirtualService;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_TargetIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_TargetIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action.Target = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Target;
                requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRouteRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite = null;
            
             // populate Rewrite
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_RewriteIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite = new Amazon.AppMesh.Model.HttpGatewayRouteRewrite();
            Amazon.AppMesh.Model.GatewayRouteHostnameRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_HostnameIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameRewrite();
            Amazon.AppMesh.DefaultGatewayRouteRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname_spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname = null;
            if (cmdletContext.Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname_spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname = cmdletContext.Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname_spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname.DefaultTargetHostname = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname_spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_HostnameIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite.Hostname = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Hostname;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_RewriteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRoutePathRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path = null;
            
             // populate Path
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PathIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path = new Amazon.AppMesh.Model.HttpGatewayRoutePathRewrite();
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path_spec_HttpRoute_Action_Rewrite_Path_Exact = null;
            if (cmdletContext.Spec_HttpRoute_Action_Rewrite_Path_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path_spec_HttpRoute_Action_Rewrite_Path_Exact = cmdletContext.Spec_HttpRoute_Action_Rewrite_Path_Exact;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path_spec_HttpRoute_Action_Rewrite_Path_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path.Exact = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path_spec_HttpRoute_Action_Rewrite_Path_Exact;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PathIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PathIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite.Path = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Path;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_RewriteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpGatewayRoutePrefixRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix = null;
            
             // populate Prefix
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PrefixIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix = new Amazon.AppMesh.Model.HttpGatewayRoutePrefixRewrite();
            Amazon.AppMesh.DefaultGatewayRouteRewrite requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix = null;
            if (cmdletContext.Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix = cmdletContext.Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix.DefaultPrefix = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PrefixIsNull = false;
            }
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_Value = null;
            if (cmdletContext.Spec_HttpRoute_Action_Rewrite_Prefix_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_Value = cmdletContext.Spec_HttpRoute_Action_Rewrite_Prefix_Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_Value != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix.Value = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix_spec_HttpRoute_Action_Rewrite_Prefix_Value;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PrefixIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_PrefixIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite.Prefix = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite_spec_HttpRoute_Action_Rewrite_Prefix;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_RewriteIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_RewriteIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action.Rewrite = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_spec_HttpRoute_Action_Rewrite;
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
            Amazon.AppMesh.Model.HttpGatewayRouteMatch requestSpec_spec_HttpRoute_spec_HttpRoute_Match = null;
            
             // populate Match
            var requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Match = new Amazon.AppMesh.Model.HttpGatewayRouteMatch();
            List<Amazon.AppMesh.Model.HttpGatewayRouteHeader> requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Headers = null;
            if (cmdletContext.Spec_HttpRoute_Match_Headers != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Headers = cmdletContext.Spec_HttpRoute_Match_Headers;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Headers != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Headers = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Headers;
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
            System.Int32? requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Port = null;
            if (cmdletContext.Spec_HttpRoute_Match_Port != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Port = cmdletContext.Spec_HttpRoute_Match_Port.Value;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Port != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Port = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Port.Value;
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
            List<Amazon.AppMesh.Model.HttpQueryParameter> requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_QueryParameters = null;
            if (cmdletContext.Spec_HttpRoute_Match_QueryParameters != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_QueryParameters = cmdletContext.Spec_HttpRoute_Match_QueryParameters;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_QueryParameters != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.QueryParameters = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_QueryParameters;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
            Amazon.AppMesh.Model.GatewayRouteHostnameMatch requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname = null;
            
             // populate Hostname
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_HostnameIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname = new Amazon.AppMesh.Model.GatewayRouteHostnameMatch();
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Exact = null;
            if (cmdletContext.Spec_HttpRoute_Match_Hostname_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Exact = cmdletContext.Spec_HttpRoute_Match_Hostname_Exact;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname.Exact = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Exact;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_HostnameIsNull = false;
            }
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Suffix = null;
            if (cmdletContext.Spec_HttpRoute_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Suffix = cmdletContext.Spec_HttpRoute_Match_Hostname_Suffix;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Suffix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname.Suffix = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname_spec_HttpRoute_Match_Hostname_Suffix;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_HostnameIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_HostnameIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Hostname = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Hostname;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
            Amazon.AppMesh.Model.HttpPathMatch requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path = null;
            
             // populate Path
            var requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_PathIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path = new Amazon.AppMesh.Model.HttpPathMatch();
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Exact = null;
            if (cmdletContext.Spec_HttpRoute_Match_Path_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Exact = cmdletContext.Spec_HttpRoute_Match_Path_Exact;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Exact != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path.Exact = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Exact;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_PathIsNull = false;
            }
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Regex = null;
            if (cmdletContext.Spec_HttpRoute_Match_Path_Regex != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Regex = cmdletContext.Spec_HttpRoute_Match_Path_Regex;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Regex != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path.Regex = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path_spec_HttpRoute_Match_Path_Regex;
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_PathIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_PathIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Path = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_spec_HttpRoute_Match_Path;
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
            if (cmdletContext.VirtualGatewayName != null)
            {
                request.VirtualGatewayName = cmdletContext.VirtualGatewayName;
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
        
        private Amazon.AppMesh.Model.CreateGatewayRouteResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.CreateGatewayRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "CreateGatewayRoute");
            try
            {
                #if DESKTOP
                return client.CreateGatewayRoute(request);
                #elif CORECLR
                return client.CreateGatewayRouteAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayRouteName { get; set; }
            public System.String MeshName { get; set; }
            public System.String MeshOwner { get; set; }
            public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
            public System.Int32? Spec_GrpcRoute_Action_Target_Port { get; set; }
            public System.String Spec_GrpcRoute_Action_Target_VirtualService { get; set; }
            public System.String Spec_GrpcRoute_Match_Hostname_Exact { get; set; }
            public System.String Spec_GrpcRoute_Match_Hostname_Suffix { get; set; }
            public List<Amazon.AppMesh.Model.GrpcGatewayRouteMetadata> Match_Metadata { get; set; }
            public System.Int32? Spec_GrpcRoute_Match_Port { get; set; }
            public System.String Spec_GrpcRoute_Match_ServiceName { get; set; }
            public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
            public System.String Spec_Http2Route_Action_Rewrite_Path_Exact { get; set; }
            public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix { get; set; }
            public System.String Spec_Http2Route_Action_Rewrite_Prefix_Value { get; set; }
            public System.Int32? Spec_Http2Route_Action_Target_Port { get; set; }
            public System.String Spec_Http2Route_Action_Target_VirtualService { get; set; }
            public List<Amazon.AppMesh.Model.HttpGatewayRouteHeader> Spec_Http2Route_Match_Headers { get; set; }
            public System.String Spec_Http2Route_Match_Hostname_Exact { get; set; }
            public System.String Spec_Http2Route_Match_Hostname_Suffix { get; set; }
            public Amazon.AppMesh.HttpMethod Spec_Http2Route_Match_Method { get; set; }
            public System.String Path_Exact { get; set; }
            public System.String Spec_Http2Route_Match_Path_Regex { get; set; }
            public System.Int32? Spec_Http2Route_Match_Port { get; set; }
            public System.String Spec_Http2Route_Match_Prefix { get; set; }
            public List<Amazon.AppMesh.Model.HttpQueryParameter> Spec_Http2Route_Match_QueryParameters { get; set; }
            public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname { get; set; }
            public System.String Spec_HttpRoute_Action_Rewrite_Path_Exact { get; set; }
            public Amazon.AppMesh.DefaultGatewayRouteRewrite Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix { get; set; }
            public System.String Spec_HttpRoute_Action_Rewrite_Prefix_Value { get; set; }
            public System.Int32? Spec_HttpRoute_Action_Target_Port { get; set; }
            public System.String Spec_HttpRoute_Action_Target_VirtualService { get; set; }
            public List<Amazon.AppMesh.Model.HttpGatewayRouteHeader> Spec_HttpRoute_Match_Headers { get; set; }
            public System.String Spec_HttpRoute_Match_Hostname_Exact { get; set; }
            public System.String Spec_HttpRoute_Match_Hostname_Suffix { get; set; }
            public Amazon.AppMesh.HttpMethod Spec_HttpRoute_Match_Method { get; set; }
            public System.String Spec_HttpRoute_Match_Path_Exact { get; set; }
            public System.String Spec_HttpRoute_Match_Path_Regex { get; set; }
            public System.Int32? Spec_HttpRoute_Match_Port { get; set; }
            public System.String Spec_HttpRoute_Match_Prefix { get; set; }
            public List<Amazon.AppMesh.Model.HttpQueryParameter> Spec_HttpRoute_Match_QueryParameters { get; set; }
            public System.Int32? Spec_Priority { get; set; }
            public List<Amazon.AppMesh.Model.TagRef> Tag { get; set; }
            public System.String VirtualGatewayName { get; set; }
            public System.Func<Amazon.AppMesh.Model.CreateGatewayRouteResponse, NewAMSHGatewayRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayRoute;
        }
        
    }
}
