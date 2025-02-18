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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Associates a package with an Amazon OpenSearch Service domain. For more information,
    /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/custom-packages.html">Custom
    /// packages for Amazon OpenSearch Service</a>.
    /// </summary>
    [Cmdlet("Start", "OSAssociatePackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.DomainPackageDetails")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service AssociatePackage API operation.", Operation = new[] {"AssociatePackage"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.AssociatePackageResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.DomainPackageDetails or Amazon.OpenSearchService.Model.AssociatePackageResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.DomainPackageDetails object.",
        "The service call response (type Amazon.OpenSearchService.Model.AssociatePackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartOSAssociatePackageCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>Name of the domain to associate the package with.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter KeyStoreAccessOption_KeyAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Role ARN to access the KeyStore Key</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociationConfiguration_KeyStoreAccessOption_KeyAccessRoleArn")]
        public System.String KeyStoreAccessOption_KeyAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter KeyStoreAccessOption_KeyStoreAccessEnabled
        /// <summary>
        /// <para>
        /// <para>This indicates whether Key Store access is enabled </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociationConfiguration_KeyStoreAccessOption_KeyStoreAccessEnabled")]
        public System.Boolean? KeyStoreAccessOption_KeyStoreAccessEnabled { get; set; }
        #endregion
        
        #region Parameter PackageID
        /// <summary>
        /// <para>
        /// <para>Internal ID of the package to associate with a domain. Use <c>DescribePackages</c>
        /// to find this value. </para>
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
        public System.String PackageID { get; set; }
        #endregion
        
        #region Parameter PrerequisitePackageIDList
        /// <summary>
        /// <para>
        /// <para>A list of package IDs that must be associated with the domain before the package specified
        /// in the request can be associated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PrerequisitePackageIDList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainPackageDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.AssociatePackageResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.AssociatePackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainPackageDetails";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OSAssociatePackage (AssociatePackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.AssociatePackageResponse, StartOSAssociatePackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyStoreAccessOption_KeyAccessRoleArn = this.KeyStoreAccessOption_KeyAccessRoleArn;
            context.KeyStoreAccessOption_KeyStoreAccessEnabled = this.KeyStoreAccessOption_KeyStoreAccessEnabled;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageID = this.PackageID;
            #if MODULAR
            if (this.PackageID == null && ParameterWasBound(nameof(this.PackageID)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrerequisitePackageIDList != null)
            {
                context.PrerequisitePackageIDList = new List<System.String>(this.PrerequisitePackageIDList);
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
            var request = new Amazon.OpenSearchService.Model.AssociatePackageRequest();
            
            
             // populate AssociationConfiguration
            var requestAssociationConfigurationIsNull = true;
            request.AssociationConfiguration = new Amazon.OpenSearchService.Model.PackageAssociationConfiguration();
            Amazon.OpenSearchService.Model.KeyStoreAccessOption requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption = null;
            
             // populate KeyStoreAccessOption
            var requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOptionIsNull = true;
            requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption = new Amazon.OpenSearchService.Model.KeyStoreAccessOption();
            System.String requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyAccessRoleArn = null;
            if (cmdletContext.KeyStoreAccessOption_KeyAccessRoleArn != null)
            {
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyAccessRoleArn = cmdletContext.KeyStoreAccessOption_KeyAccessRoleArn;
            }
            if (requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyAccessRoleArn != null)
            {
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption.KeyAccessRoleArn = requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyAccessRoleArn;
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOptionIsNull = false;
            }
            System.Boolean? requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyStoreAccessEnabled = null;
            if (cmdletContext.KeyStoreAccessOption_KeyStoreAccessEnabled != null)
            {
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyStoreAccessEnabled = cmdletContext.KeyStoreAccessOption_KeyStoreAccessEnabled.Value;
            }
            if (requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyStoreAccessEnabled != null)
            {
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption.KeyStoreAccessEnabled = requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption_keyStoreAccessOption_KeyStoreAccessEnabled.Value;
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOptionIsNull = false;
            }
             // determine if requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption should be set to null
            if (requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOptionIsNull)
            {
                requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption = null;
            }
            if (requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption != null)
            {
                request.AssociationConfiguration.KeyStoreAccessOption = requestAssociationConfiguration_associationConfiguration_KeyStoreAccessOption;
                requestAssociationConfigurationIsNull = false;
            }
             // determine if request.AssociationConfiguration should be set to null
            if (requestAssociationConfigurationIsNull)
            {
                request.AssociationConfiguration = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.PackageID != null)
            {
                request.PackageID = cmdletContext.PackageID;
            }
            if (cmdletContext.PrerequisitePackageIDList != null)
            {
                request.PrerequisitePackageIDList = cmdletContext.PrerequisitePackageIDList;
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
        
        private Amazon.OpenSearchService.Model.AssociatePackageResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.AssociatePackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "AssociatePackage");
            try
            {
                return client.AssociatePackageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KeyStoreAccessOption_KeyAccessRoleArn { get; set; }
            public System.Boolean? KeyStoreAccessOption_KeyStoreAccessEnabled { get; set; }
            public System.String DomainName { get; set; }
            public System.String PackageID { get; set; }
            public List<System.String> PrerequisitePackageIDList { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.AssociatePackageResponse, StartOSAssociatePackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainPackageDetails;
        }
        
    }
}
