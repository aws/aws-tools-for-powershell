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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Creates an AccessGrant that authorizes a principal to administer an organization domain.
    /// </summary>
    [Cmdlet("New", "CWOMDomainAccessGrantForOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchOmni.Model.OrganizationAccessGrant")]
    [AWSCmdlet("Calls the CloudWatch Omni CreateDomainAccessGrantForOrganization API operation.", Operation = new[] {"CreateDomainAccessGrantForOrganization"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.OrganizationAccessGrant or Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse",
        "This cmdlet returns an Amazon.CloudWatchOmni.Model.OrganizationAccessGrant object.",
        "The service call response (type Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWOMDomainAccessGrantForOrganizationCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the organization domain to create the grant on.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name that identifies the access grant.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The permission to grant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.OrganizationGrantPermission")]
        public Amazon.CloudWatchOmni.OrganizationGrantPermission Permission { get; set; }
        #endregion
        
        #region Parameter Principal_PrincipalAttribute
        /// <summary>
        /// <para>
        /// <para>Attribute conditions for attribute-based access. When provided, the grant targets
        /// any principal matching all specified conditions. Supported only for IDC_USER principals.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_PrincipalAttributes")]
        public Amazon.CloudWatchOmni.Model.AccessGrantPrincipalAttribute[] Principal_PrincipalAttribute { get; set; }
        #endregion
        
        #region Parameter Principal_PrincipalId
        /// <summary>
        /// <para>
        /// <para>The ID of the principal receiving the grant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal_PrincipalId { get; set; }
        #endregion
        
        #region Parameter Principal_PrincipalType
        /// <summary>
        /// <para>
        /// <para>The type of principal receiving the grant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.OrganizationGrantPrincipalType")]
        public Amazon.CloudWatchOmni.OrganizationGrantPrincipalType Principal_PrincipalType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the access grant.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for safe retries. Repeated requests with the same token return the
        /// original result instead of creating a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessGrant'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessGrant";
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOMDomainAccessGrantForOrganization (CreateDomainAccessGrantForOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse, NewCWOMDomainAccessGrantForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Permission = this.Permission;
            #if MODULAR
            if (this.Permission == null && ParameterWasBound(nameof(this.Permission)))
            {
                WriteWarning("You are passing $null as a value for parameter Permission which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Principal_PrincipalAttribute != null)
            {
                context.Principal_PrincipalAttribute = new List<Amazon.CloudWatchOmni.Model.AccessGrantPrincipalAttribute>(this.Principal_PrincipalAttribute);
            }
            context.Principal_PrincipalId = this.Principal_PrincipalId;
            context.Principal_PrincipalType = this.Principal_PrincipalType;
            #if MODULAR
            if (this.Principal_PrincipalType == null && ParameterWasBound(nameof(this.Principal_PrincipalType)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal_PrincipalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permission = cmdletContext.Permission;
            }
            
             // populate Principal
            var requestPrincipalIsNull = true;
            request.Principal = new Amazon.CloudWatchOmni.Model.OrganizationAccessGrantPrincipal();
            List<Amazon.CloudWatchOmni.Model.AccessGrantPrincipalAttribute> requestPrincipal_principal_PrincipalAttribute = null;
            if (cmdletContext.Principal_PrincipalAttribute != null)
            {
                requestPrincipal_principal_PrincipalAttribute = cmdletContext.Principal_PrincipalAttribute;
            }
            if (requestPrincipal_principal_PrincipalAttribute != null)
            {
                request.Principal.PrincipalAttributes = requestPrincipal_principal_PrincipalAttribute;
                requestPrincipalIsNull = false;
            }
            System.String requestPrincipal_principal_PrincipalId = null;
            if (cmdletContext.Principal_PrincipalId != null)
            {
                requestPrincipal_principal_PrincipalId = cmdletContext.Principal_PrincipalId;
            }
            if (requestPrincipal_principal_PrincipalId != null)
            {
                request.Principal.PrincipalId = requestPrincipal_principal_PrincipalId;
                requestPrincipalIsNull = false;
            }
            Amazon.CloudWatchOmni.OrganizationGrantPrincipalType requestPrincipal_principal_PrincipalType = null;
            if (cmdletContext.Principal_PrincipalType != null)
            {
                requestPrincipal_principal_PrincipalType = cmdletContext.Principal_PrincipalType;
            }
            if (requestPrincipal_principal_PrincipalType != null)
            {
                request.Principal.PrincipalType = requestPrincipal_principal_PrincipalType;
                requestPrincipalIsNull = false;
            }
             // determine if request.Principal should be set to null
            if (requestPrincipalIsNull)
            {
                request.Principal = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "CreateDomainAccessGrantForOrganization");
            try
            {
                return client.CreateDomainAccessGrantForOrganizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String Name { get; set; }
            public Amazon.CloudWatchOmni.OrganizationGrantPermission Permission { get; set; }
            public List<Amazon.CloudWatchOmni.Model.AccessGrantPrincipalAttribute> Principal_PrincipalAttribute { get; set; }
            public System.String Principal_PrincipalId { get; set; }
            public Amazon.CloudWatchOmni.OrganizationGrantPrincipalType Principal_PrincipalType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.CreateDomainAccessGrantForOrganizationResponse, NewCWOMDomainAccessGrantForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessGrant;
        }
        
    }
}
