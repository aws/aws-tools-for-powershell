/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.MigrationHubRefactorSpaces;
using Amazon.MigrationHubRefactorSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.MHRS
{
    /// <summary>
    /// Creates an Amazon Web Services Migration Hub Refactor Spaces application. The account
    /// that owns the environment also owns the applications created inside the environment,
    /// regardless of the account that creates the application. Refactor Spaces provisions
    /// an Amazon API Gateway, API Gateway VPC link, and Network Load Balancer for the application
    /// proxy inside your account.
    /// 
    ///  
    /// <para>
    /// In environments created with a <a href="https://docs.aws.amazon.com/migrationhub-refactor-spaces/latest/APIReference/API_CreateEnvironment.html#migrationhubrefactorspaces-CreateEnvironment-request-NetworkFabricType">CreateEnvironment:NetworkFabricType</a>
    /// of <c>NONE</c> you need to configure <a href="https://docs.aws.amazon.com/whitepapers/latest/aws-vpc-connectivity-options/amazon-vpc-to-amazon-vpc-connectivity-options.html">
    /// VPC to VPC connectivity</a> between your service VPC and the application proxy VPC
    /// to route traffic through the application proxy to a service with a private URL endpoint.
    /// For more information, see <a href="https://docs.aws.amazon.com/migrationhub-refactor-spaces/latest/userguide/getting-started-create-application.html">
    /// Create an application</a> in the <i>Refactor Spaces User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "MHRSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Refactor Spaces CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse object containing multiple properties."
    )]
    public partial class NewMHRSApplicationCmdlet : AmazonMigrationHubRefactorSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiGatewayProxy_EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint to use for the API Gateway proxy. If no value is specified in
        /// the request, the value is set to <c>REGIONAL</c> by default.</para><para>If the value is set to <c>PRIVATE</c> in the request, this creates a private API endpoint
        /// that is isolated from the public internet. The private endpoint can only be accessed
        /// by using Amazon Virtual Private Cloud (Amazon VPC) interface endpoints for the Amazon
        /// API Gateway that has been granted access. For more information about creating a private
        /// connection with Refactor Spaces and interface endpoint (Amazon Web Services PrivateLink)
        /// availability, see <a href="https://docs.aws.amazon.com/migrationhub-refactor-spaces/latest/userguide/vpc-interface-endpoints.html">Access
        /// Refactor Spaces using an interface endpoint (Amazon Web Services PrivateLink)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.ApiGatewayEndpointType")]
        public Amazon.MigrationHubRefactorSpaces.ApiGatewayEndpointType ApiGatewayProxy_EndpointType { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the environment.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to use for the application. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProxyType
        /// <summary>
        /// <para>
        /// <para>The proxy type of the proxy created within the application. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.ProxyType")]
        public Amazon.MigrationHubRefactorSpaces.ProxyType ProxyType { get; set; }
        #endregion
        
        #region Parameter ApiGatewayProxy_StageName
        /// <summary>
        /// <para>
        /// <para>The name of the API Gateway stage. The name defaults to <c>prod</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiGatewayProxy_StageName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the application. A tag is a label that you assign to an Amazon
        /// Web Services resource. Each tag consists of a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private cloud (VPC).</para>
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
        public System.String VpcId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHRSApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse, NewMHRSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiGatewayProxy_EndpointType = this.ApiGatewayProxy_EndpointType;
            context.ApiGatewayProxy_StageName = this.ApiGatewayProxy_StageName;
            context.ClientToken = this.ClientToken;
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProxyType = this.ProxyType;
            #if MODULAR
            if (this.ProxyType == null && ParameterWasBound(nameof(this.ProxyType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationRequest();
            
            
             // populate ApiGatewayProxy
            var requestApiGatewayProxyIsNull = true;
            request.ApiGatewayProxy = new Amazon.MigrationHubRefactorSpaces.Model.ApiGatewayProxyInput();
            Amazon.MigrationHubRefactorSpaces.ApiGatewayEndpointType requestApiGatewayProxy_apiGatewayProxy_EndpointType = null;
            if (cmdletContext.ApiGatewayProxy_EndpointType != null)
            {
                requestApiGatewayProxy_apiGatewayProxy_EndpointType = cmdletContext.ApiGatewayProxy_EndpointType;
            }
            if (requestApiGatewayProxy_apiGatewayProxy_EndpointType != null)
            {
                request.ApiGatewayProxy.EndpointType = requestApiGatewayProxy_apiGatewayProxy_EndpointType;
                requestApiGatewayProxyIsNull = false;
            }
            System.String requestApiGatewayProxy_apiGatewayProxy_StageName = null;
            if (cmdletContext.ApiGatewayProxy_StageName != null)
            {
                requestApiGatewayProxy_apiGatewayProxy_StageName = cmdletContext.ApiGatewayProxy_StageName;
            }
            if (requestApiGatewayProxy_apiGatewayProxy_StageName != null)
            {
                request.ApiGatewayProxy.StageName = requestApiGatewayProxy_apiGatewayProxy_StageName;
                requestApiGatewayProxyIsNull = false;
            }
             // determine if request.ApiGatewayProxy should be set to null
            if (requestApiGatewayProxyIsNull)
            {
                request.ApiGatewayProxy = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProxyType != null)
            {
                request.ProxyType = cmdletContext.ProxyType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonMigrationHubRefactorSpaces client, Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Refactor Spaces", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.MigrationHubRefactorSpaces.ApiGatewayEndpointType ApiGatewayProxy_EndpointType { get; set; }
            public System.String ApiGatewayProxy_StageName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String Name { get; set; }
            public Amazon.MigrationHubRefactorSpaces.ProxyType ProxyType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.MigrationHubRefactorSpaces.Model.CreateApplicationResponse, NewMHRSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
