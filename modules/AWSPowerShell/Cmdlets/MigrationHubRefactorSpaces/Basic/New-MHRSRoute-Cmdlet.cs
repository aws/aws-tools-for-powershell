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
using Amazon.MigrationHubRefactorSpaces;
using Amazon.MigrationHubRefactorSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.MHRS
{
    /// <summary>
    /// Creates an Amazon Web Services Migration Hub Refactor Spaces route. The account owner
    /// of the service resource is always the environment owner, regardless of which account
    /// creates the route. Routes target a service in the application. If an application does
    /// not have any routes, then the first route must be created as a <code>DEFAULT</code><code>RouteType</code>.
    /// 
    ///  
    /// <para>
    /// When created, the default route defaults to an active state so state is not a required
    /// input. However, like all other state values the state of the default route can be
    /// updated after creation, but only when all other routes are also inactive. Conversely,
    /// no route can be active without the default route also being active.
    /// </para><para>
    /// When you create a route, Refactor Spaces configures the Amazon API Gateway to send
    /// traffic to the target service as follows:
    /// </para><ul><li><para>
    /// If the service has a URL endpoint, and the endpoint resolves to a private IP address,
    /// Refactor Spaces routes traffic using the API Gateway VPC link. 
    /// </para></li><li><para>
    /// If the service has a URL endpoint, and the endpoint resolves to a public IP address,
    /// Refactor Spaces routes traffic over the public internet.
    /// </para></li><li><para>
    /// If the service has an Lambda function endpoint, then Refactor Spaces configures the
    /// Lambda function's resource policy to allow the application's API Gateway to invoke
    /// the function.
    /// </para></li></ul><para>
    /// A one-time health check is performed on the service when either the route is updated
    /// from inactive to active, or when it is created with an active state. If the health
    /// check fails, the route transitions the route state to <code>FAILED</code>, an error
    /// code of <code>SERVICE_ENDPOINT_HEALTH_CHECK_FAILURE</code> is provided, and no traffic
    /// is sent to the service.
    /// </para><para>
    /// For Lambda functions, the Lambda function state is checked. If the function is not
    /// active, the function configuration is updated so that Lambda resources are provisioned.
    /// If the Lambda state is <code>Failed</code>, then the route creation fails. For more
    /// information, see the <a href="https://docs.aws.amazon.com/lambda/latest/dg/API_GetFunctionConfiguration.html#SSS-GetFunctionConfiguration-response-State">GetFunctionConfiguration's
    /// State response parameter</a> in the <i>Lambda Developer Guide</i>.
    /// </para><para>
    /// For Lambda endpoints, a check is performed to determine that a Lambda function with
    /// the specified ARN exists. If it does not exist, the health check fails. For public
    /// URLs, a connection is opened to the public endpoint. If the URL is not reachable,
    /// the health check fails. 
    /// </para><para>
    /// Refactor Spaces automatically resolves the public Domain Name System (DNS) names that
    /// are set in <a>CreateServiceRequest$UrlEndpoint</a> when you create a service. The
    /// DNS names resolve when the DNS time-to-live (TTL) expires, or every 60 seconds for
    /// TTLs less than 60 seconds. This periodic DNS resolution ensures that the route configuration
    /// remains up-to-date. 
    /// </para><para>
    /// For private URLS, a target group is created on the Elastic Load Balancing and the
    /// target group health check is run. The <code>HealthCheckProtocol</code>, <code>HealthCheckPort</code>,
    /// and <code>HealthCheckPath</code> are the same protocol, port, and path specified in
    /// the URL or health URL, if used. All other settings use the default values, as described
    /// in <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/target-group-health-checks.html">Health
    /// checks for your target groups</a>. The health check is considered successful if at
    /// least one target within the target group transitions to a healthy state.
    /// </para><para>
    /// Services can have HTTP or HTTPS URL endpoints. For HTTPS URLs, publicly-signed certificates
    /// are supported. Private Certificate Authorities (CAs) are permitted only if the CA's
    /// domain is also publicly resolvable.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MHRSRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Refactor Spaces CreateRoute API operation.", Operation = new[] {"CreateRoute"}, SelectReturnType = typeof(Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse",
        "This cmdlet returns an Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMHRSRouteCmdlet : AmazonMigrationHubRefactorSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter DefaultRoute_ActivationState
        /// <summary>
        /// <para>
        /// <para>If set to <code>ACTIVE</code>, traffic is forwarded to this route’s service after
        /// the route is created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.RouteActivationState")]
        public Amazon.MigrationHubRefactorSpaces.RouteActivationState DefaultRoute_ActivationState { get; set; }
        #endregion
        
        #region Parameter UriPathRoute_ActivationState
        /// <summary>
        /// <para>
        /// <para>If set to <code>ACTIVE</code>, traffic is forwarded to this route’s service after
        /// the route is created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.RouteActivationState")]
        public Amazon.MigrationHubRefactorSpaces.RouteActivationState UriPathRoute_ActivationState { get; set; }
        #endregion
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the application within which the route is being created.</para>
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
        public System.String ApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the environment in which the route is created.</para>
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
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter UriPathRoute_IncludeChildPath
        /// <summary>
        /// <para>
        /// <para>Indicates whether to match all subpaths of the given source path. If this value is
        /// <code>false</code>, requests must match the source path exactly before they are forwarded
        /// to this route's service. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UriPathRoute_IncludeChildPaths")]
        public System.Boolean? UriPathRoute_IncludeChildPath { get; set; }
        #endregion
        
        #region Parameter UriPathRoute_Method
        /// <summary>
        /// <para>
        /// <para>A list of HTTP methods to match. An empty list matches all values. If a method is
        /// present, only HTTP requests using that method are forwarded to this route’s service.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UriPathRoute_Methods")]
        public System.String[] UriPathRoute_Method { get; set; }
        #endregion
        
        #region Parameter RouteType
        /// <summary>
        /// <para>
        /// <para>The route type of the route. <code>DEFAULT</code> indicates that all traffic that
        /// does not match another route is forwarded to the default route. Applications must
        /// have a default route before any other routes can be created. <code>URI_PATH</code>
        /// indicates a route that is based on a URI path.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.RouteType")]
        public Amazon.MigrationHubRefactorSpaces.RouteType RouteType { get; set; }
        #endregion
        
        #region Parameter ServiceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the service in which the route is created. Traffic that matches this route
        /// is forwarded to this service.</para>
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
        public System.String ServiceIdentifier { get; set; }
        #endregion
        
        #region Parameter UriPathRoute_SourcePath
        /// <summary>
        /// <para>
        /// <para>The path to use to match traffic. Paths must start with <code>/</code> and are relative
        /// to the base of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UriPathRoute_SourcePath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the route. A tag is a label that you assign to an Amazon Web
        /// Services resource. Each tag consists of a key-value pair.. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHRSRoute (CreateRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse, NewMHRSRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationIdentifier = this.ApplicationIdentifier;
            #if MODULAR
            if (this.ApplicationIdentifier == null && ParameterWasBound(nameof(this.ApplicationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DefaultRoute_ActivationState = this.DefaultRoute_ActivationState;
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RouteType = this.RouteType;
            #if MODULAR
            if (this.RouteType == null && ParameterWasBound(nameof(this.RouteType)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceIdentifier = this.ServiceIdentifier;
            #if MODULAR
            if (this.ServiceIdentifier == null && ParameterWasBound(nameof(this.ServiceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.UriPathRoute_ActivationState = this.UriPathRoute_ActivationState;
            context.UriPathRoute_IncludeChildPath = this.UriPathRoute_IncludeChildPath;
            if (this.UriPathRoute_Method != null)
            {
                context.UriPathRoute_Method = new List<System.String>(this.UriPathRoute_Method);
            }
            context.UriPathRoute_SourcePath = this.UriPathRoute_SourcePath;
            
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
            var request = new Amazon.MigrationHubRefactorSpaces.Model.CreateRouteRequest();
            
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DefaultRoute
            var requestDefaultRouteIsNull = true;
            request.DefaultRoute = new Amazon.MigrationHubRefactorSpaces.Model.DefaultRouteInput();
            Amazon.MigrationHubRefactorSpaces.RouteActivationState requestDefaultRoute_defaultRoute_ActivationState = null;
            if (cmdletContext.DefaultRoute_ActivationState != null)
            {
                requestDefaultRoute_defaultRoute_ActivationState = cmdletContext.DefaultRoute_ActivationState;
            }
            if (requestDefaultRoute_defaultRoute_ActivationState != null)
            {
                request.DefaultRoute.ActivationState = requestDefaultRoute_defaultRoute_ActivationState;
                requestDefaultRouteIsNull = false;
            }
             // determine if request.DefaultRoute should be set to null
            if (requestDefaultRouteIsNull)
            {
                request.DefaultRoute = null;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            if (cmdletContext.RouteType != null)
            {
                request.RouteType = cmdletContext.RouteType;
            }
            if (cmdletContext.ServiceIdentifier != null)
            {
                request.ServiceIdentifier = cmdletContext.ServiceIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate UriPathRoute
            var requestUriPathRouteIsNull = true;
            request.UriPathRoute = new Amazon.MigrationHubRefactorSpaces.Model.UriPathRouteInput();
            Amazon.MigrationHubRefactorSpaces.RouteActivationState requestUriPathRoute_uriPathRoute_ActivationState = null;
            if (cmdletContext.UriPathRoute_ActivationState != null)
            {
                requestUriPathRoute_uriPathRoute_ActivationState = cmdletContext.UriPathRoute_ActivationState;
            }
            if (requestUriPathRoute_uriPathRoute_ActivationState != null)
            {
                request.UriPathRoute.ActivationState = requestUriPathRoute_uriPathRoute_ActivationState;
                requestUriPathRouteIsNull = false;
            }
            System.Boolean? requestUriPathRoute_uriPathRoute_IncludeChildPath = null;
            if (cmdletContext.UriPathRoute_IncludeChildPath != null)
            {
                requestUriPathRoute_uriPathRoute_IncludeChildPath = cmdletContext.UriPathRoute_IncludeChildPath.Value;
            }
            if (requestUriPathRoute_uriPathRoute_IncludeChildPath != null)
            {
                request.UriPathRoute.IncludeChildPaths = requestUriPathRoute_uriPathRoute_IncludeChildPath.Value;
                requestUriPathRouteIsNull = false;
            }
            List<System.String> requestUriPathRoute_uriPathRoute_Method = null;
            if (cmdletContext.UriPathRoute_Method != null)
            {
                requestUriPathRoute_uriPathRoute_Method = cmdletContext.UriPathRoute_Method;
            }
            if (requestUriPathRoute_uriPathRoute_Method != null)
            {
                request.UriPathRoute.Methods = requestUriPathRoute_uriPathRoute_Method;
                requestUriPathRouteIsNull = false;
            }
            System.String requestUriPathRoute_uriPathRoute_SourcePath = null;
            if (cmdletContext.UriPathRoute_SourcePath != null)
            {
                requestUriPathRoute_uriPathRoute_SourcePath = cmdletContext.UriPathRoute_SourcePath;
            }
            if (requestUriPathRoute_uriPathRoute_SourcePath != null)
            {
                request.UriPathRoute.SourcePath = requestUriPathRoute_uriPathRoute_SourcePath;
                requestUriPathRouteIsNull = false;
            }
             // determine if request.UriPathRoute should be set to null
            if (requestUriPathRouteIsNull)
            {
                request.UriPathRoute = null;
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
        
        private Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse CallAWSServiceOperation(IAmazonMigrationHubRefactorSpaces client, Amazon.MigrationHubRefactorSpaces.Model.CreateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Refactor Spaces", "CreateRoute");
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
            public System.String ApplicationIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.MigrationHubRefactorSpaces.RouteActivationState DefaultRoute_ActivationState { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public Amazon.MigrationHubRefactorSpaces.RouteType RouteType { get; set; }
            public System.String ServiceIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.MigrationHubRefactorSpaces.RouteActivationState UriPathRoute_ActivationState { get; set; }
            public System.Boolean? UriPathRoute_IncludeChildPath { get; set; }
            public List<System.String> UriPathRoute_Method { get; set; }
            public System.String UriPathRoute_SourcePath { get; set; }
            public System.Func<Amazon.MigrationHubRefactorSpaces.Model.CreateRouteResponse, NewMHRSRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
