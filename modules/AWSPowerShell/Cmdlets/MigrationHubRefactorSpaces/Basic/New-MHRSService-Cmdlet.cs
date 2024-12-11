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
    /// Creates an Amazon Web Services Migration Hub Refactor Spaces service. The account
    /// owner of the service is always the environment owner, regardless of which account
    /// in the environment creates the service. Services have either a URL endpoint in a virtual
    /// private cloud (VPC), or a Lambda function endpoint.
    /// 
    ///  <important><para>
    /// If an Amazon Web Services resource is launched in a service VPC, and you want it to
    /// be accessible to all of an environment’s services with VPCs and routes, apply the
    /// <c>RefactorSpacesSecurityGroup</c> to the resource. Alternatively, to add more cross-account
    /// constraints, apply your own security group.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "MHRSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Refactor Spaces CreateService API operation.", Operation = new[] {"CreateService"}, SelectReturnType = typeof(Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse",
        "This cmdlet returns an Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse object containing multiple properties."
    )]
    public partial class NewMHRSServiceCmdlet : AmazonMigrationHubRefactorSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the application which the service is created.</para>
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
        
        #region Parameter LambdaEndpoint_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function or alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaEndpoint_Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint to use for the service. The type can be a URL in a VPC or an
        /// Lambda function.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MigrationHubRefactorSpaces.ServiceEndpointType")]
        public Amazon.MigrationHubRefactorSpaces.ServiceEndpointType EndpointType { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the environment in which the service is created.</para>
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
        
        #region Parameter UrlEndpoint_HealthUrl
        /// <summary>
        /// <para>
        /// <para>The health check URL of the URL endpoint type. If the URL is a public endpoint, the
        /// <c>HealthUrl</c> must also be a public endpoint. If the URL is a private endpoint
        /// inside a virtual private cloud (VPC), the health URL must also be a private endpoint,
        /// and the host must be the same as the URL. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UrlEndpoint_HealthUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the service.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the service. A tag is a label that you assign to an Amazon Web
        /// Services resource. Each tag consists of a key-value pair.. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UrlEndpoint_Url
        /// <summary>
        /// <para>
        /// <para>The URL to route traffic to. The URL must be an <a href="https://datatracker.ietf.org/doc/html/rfc3986">rfc3986-formatted
        /// URL</a>. If the host is a domain name, the name must be resolvable over the public
        /// internet. If the scheme is <c>https</c>, the top level domain of the host must be
        /// listed in the <a href="https://www.iana.org/domains/root/db">IANA root zone database</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UrlEndpoint_Url { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHRSService (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse, NewMHRSServiceCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.EndpointType = this.EndpointType;
            #if MODULAR
            if (this.EndpointType == null && ParameterWasBound(nameof(this.EndpointType)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LambdaEndpoint_Arn = this.LambdaEndpoint_Arn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.UrlEndpoint_HealthUrl = this.UrlEndpoint_HealthUrl;
            context.UrlEndpoint_Url = this.UrlEndpoint_Url;
            context.VpcId = this.VpcId;
            
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
            var request = new Amazon.MigrationHubRefactorSpaces.Model.CreateServiceRequest();
            
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            
             // populate LambdaEndpoint
            var requestLambdaEndpointIsNull = true;
            request.LambdaEndpoint = new Amazon.MigrationHubRefactorSpaces.Model.LambdaEndpointInput();
            System.String requestLambdaEndpoint_lambdaEndpoint_Arn = null;
            if (cmdletContext.LambdaEndpoint_Arn != null)
            {
                requestLambdaEndpoint_lambdaEndpoint_Arn = cmdletContext.LambdaEndpoint_Arn;
            }
            if (requestLambdaEndpoint_lambdaEndpoint_Arn != null)
            {
                request.LambdaEndpoint.Arn = requestLambdaEndpoint_lambdaEndpoint_Arn;
                requestLambdaEndpointIsNull = false;
            }
             // determine if request.LambdaEndpoint should be set to null
            if (requestLambdaEndpointIsNull)
            {
                request.LambdaEndpoint = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate UrlEndpoint
            var requestUrlEndpointIsNull = true;
            request.UrlEndpoint = new Amazon.MigrationHubRefactorSpaces.Model.UrlEndpointInput();
            System.String requestUrlEndpoint_urlEndpoint_HealthUrl = null;
            if (cmdletContext.UrlEndpoint_HealthUrl != null)
            {
                requestUrlEndpoint_urlEndpoint_HealthUrl = cmdletContext.UrlEndpoint_HealthUrl;
            }
            if (requestUrlEndpoint_urlEndpoint_HealthUrl != null)
            {
                request.UrlEndpoint.HealthUrl = requestUrlEndpoint_urlEndpoint_HealthUrl;
                requestUrlEndpointIsNull = false;
            }
            System.String requestUrlEndpoint_urlEndpoint_Url = null;
            if (cmdletContext.UrlEndpoint_Url != null)
            {
                requestUrlEndpoint_urlEndpoint_Url = cmdletContext.UrlEndpoint_Url;
            }
            if (requestUrlEndpoint_urlEndpoint_Url != null)
            {
                request.UrlEndpoint.Url = requestUrlEndpoint_urlEndpoint_Url;
                requestUrlEndpointIsNull = false;
            }
             // determine if request.UrlEndpoint should be set to null
            if (requestUrlEndpointIsNull)
            {
                request.UrlEndpoint = null;
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
        
        private Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonMigrationHubRefactorSpaces client, Amazon.MigrationHubRefactorSpaces.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Refactor Spaces", "CreateService");
            try
            {
                #if DESKTOP
                return client.CreateService(request);
                #elif CORECLR
                return client.CreateServiceAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.MigrationHubRefactorSpaces.ServiceEndpointType EndpointType { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String LambdaEndpoint_Arn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String UrlEndpoint_HealthUrl { get; set; }
            public System.String UrlEndpoint_Url { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.MigrationHubRefactorSpaces.Model.CreateServiceResponse, NewMHRSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
