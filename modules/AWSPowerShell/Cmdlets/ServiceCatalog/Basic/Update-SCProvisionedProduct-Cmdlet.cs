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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Requests updates to the configuration of the specified provisioned product.
    /// 
    ///  
    /// <para>
    /// If there are tags associated with the object, they cannot be updated or added. Depending
    /// on the specific updates requested, this operation can update with no interruption,
    /// with some interruption, or replace the provisioned product entirely.
    /// </para><para>
    /// You can check the status of this request using <a>DescribeRecord</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SCProvisionedProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog UpdateProvisionedProduct API operation.", Operation = new[] {"UpdateProvisionedProduct"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail or Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.RecordDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSCProvisionedProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter PathId
        /// <summary>
        /// <para>
        /// <para>The path identifier. This value is optional if the product has a default path, and
        /// required if the product has more than one path. You must provide the name or ID, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PathId { get; set; }
        #endregion
        
        #region Parameter PathName
        /// <summary>
        /// <para>
        /// <para>The name of the path. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PathName { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the product. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProductName
        /// <summary>
        /// <para>
        /// <para>The name of the product. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProductName { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioned product. You must provide the name or ID, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ProvisionedProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioned product. You cannot specify both <c>ProvisionedProductName</c>
        /// and <c>ProvisionedProductId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisionedProductName { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioning artifact. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactName { get; set; }
        #endregion
        
        #region Parameter ProvisioningParameter
        /// <summary>
        /// <para>
        /// <para>The new parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningParameters")]
        public Amazon.ServiceCatalog.Model.UpdateProvisioningParameter[] ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetAccount
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Web Services accounts that will have access to the provisioned
        /// product.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>The Amazon Web Services accounts specified should be within the list of accounts in
        /// the <c>STACKSET</c> constraint. To get the list of accounts in the <c>STACKSET</c>
        /// constraint, use the <c>DescribeProvisioningParameters</c> operation.</para><para>If no values are specified, the default value is all accounts from the <c>STACKSET</c>
        /// constraint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningPreferences_StackSetAccounts")]
        public System.String[] ProvisioningPreferences_StackSetAccount { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetFailureToleranceCount
        /// <summary>
        /// <para>
        /// <para>The number of accounts, per Region, for which this operation can fail before Service
        /// Catalog stops the operation in that Region. If the operation is stopped in a Region,
        /// Service Catalog doesn't attempt the operation in any subsequent Regions.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>Conditional: You must specify either <c>StackSetFailureToleranceCount</c> or <c>StackSetFailureTolerancePercentage</c>,
        /// but not both.</para><para>The default value is <c>0</c> if no value is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetFailureToleranceCount { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetFailureTolerancePercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of accounts, per Region, for which this stack operation can fail before
        /// Service Catalog stops the operation in that Region. If the operation is stopped in
        /// a Region, Service Catalog doesn't attempt the operation in any subsequent Regions.</para><para>When calculating the number of accounts based on the specified percentage, Service
        /// Catalog rounds down to the next whole number.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>Conditional: You must specify either <c>StackSetFailureToleranceCount</c> or <c>StackSetFailureTolerancePercentage</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetFailureTolerancePercentage { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetMaxConcurrencyCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of accounts in which to perform this operation at one time. This
        /// is dependent on the value of <c>StackSetFailureToleranceCount</c>. <c>StackSetMaxConcurrentCount</c>
        /// is at most one more than the <c>StackSetFailureToleranceCount</c>.</para><para>Note that this setting lets you specify the maximum for operations. For large deployments,
        /// under certain circumstances the actual number of accounts acted upon concurrently
        /// may be lower due to service throttling.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>Conditional: You must specify either <c>StackSetMaxConcurrentCount</c> or <c>StackSetMaxConcurrentPercentage</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyCount { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetMaxConcurrencyPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of accounts in which to perform this operation at one time.</para><para>When calculating the number of accounts based on the specified percentage, Service
        /// Catalog rounds down to the next whole number. This is true except in cases where rounding
        /// down would result is zero. In this case, Service Catalog sets the number as <c>1</c>
        /// instead.</para><para>Note that this setting lets you specify the maximum for operations. For large deployments,
        /// under certain circumstances the actual number of accounts acted upon concurrently
        /// may be lower due to service throttling.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>Conditional: You must specify either <c>StackSetMaxConcurrentCount</c> or <c>StackSetMaxConcurrentPercentage</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyPercentage { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetOperationType
        /// <summary>
        /// <para>
        /// <para>Determines what action Service Catalog performs to a stack set or a stack instance
        /// represented by the provisioned product. The default value is <c>UPDATE</c> if nothing
        /// is specified.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><dl><dt>CREATE</dt><dd><para>Creates a new stack instance in the stack set represented by the provisioned product.
        /// In this case, only new stack instances are created based on accounts and Regions;
        /// if new ProductId or ProvisioningArtifactID are passed, they will be ignored.</para></dd><dt>UPDATE</dt><dd><para>Updates the stack set represented by the provisioned product and also its stack instances.</para></dd><dt>DELETE</dt><dd><para>Deletes a stack instance in the stack set represented by the provisioned product.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.StackSetOperationType")]
        public Amazon.ServiceCatalog.StackSetOperationType ProvisioningPreferences_StackSetOperationType { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetRegion
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Web Services Regions where the provisioned product will be available.</para><para>Applicable only to a <c>CFN_STACKSET</c> provisioned product type.</para><para>The specified Regions should be within the list of Regions from the <c>STACKSET</c>
        /// constraint. To get the list of Regions in the <c>STACKSET</c> constraint, use the
        /// <c>DescribeProvisioningParameters</c> operation.</para><para>If no values are specified, the default value is all Regions from the <c>STACKSET</c>
        /// constraint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningPreferences_StackSetRegions")]
        public System.String[] ProvisioningPreferences_StackSetRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags. Requires the product to have <c>RESOURCE_UPDATE</c> constraint with
        /// <c>TagUpdatesOnProvisionedProduct</c> set to <c>ALLOWED</c> to allow tag updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ServiceCatalog.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token that uniquely identifies the provisioning update request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecordDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecordDetail";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProvisionedProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProvisionedProduct (UpdateProvisionedProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse, UpdateSCProvisionedProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.PathId = this.PathId;
            context.PathName = this.PathName;
            context.ProductId = this.ProductId;
            context.ProductName = this.ProductName;
            context.ProvisionedProductId = this.ProvisionedProductId;
            context.ProvisionedProductName = this.ProvisionedProductName;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            context.ProvisioningArtifactName = this.ProvisioningArtifactName;
            if (this.ProvisioningParameter != null)
            {
                context.ProvisioningParameter = new List<Amazon.ServiceCatalog.Model.UpdateProvisioningParameter>(this.ProvisioningParameter);
            }
            if (this.ProvisioningPreferences_StackSetAccount != null)
            {
                context.ProvisioningPreferences_StackSetAccount = new List<System.String>(this.ProvisioningPreferences_StackSetAccount);
            }
            context.ProvisioningPreferences_StackSetFailureToleranceCount = this.ProvisioningPreferences_StackSetFailureToleranceCount;
            context.ProvisioningPreferences_StackSetFailureTolerancePercentage = this.ProvisioningPreferences_StackSetFailureTolerancePercentage;
            context.ProvisioningPreferences_StackSetMaxConcurrencyCount = this.ProvisioningPreferences_StackSetMaxConcurrencyCount;
            context.ProvisioningPreferences_StackSetMaxConcurrencyPercentage = this.ProvisioningPreferences_StackSetMaxConcurrencyPercentage;
            context.ProvisioningPreferences_StackSetOperationType = this.ProvisioningPreferences_StackSetOperationType;
            if (this.ProvisioningPreferences_StackSetRegion != null)
            {
                context.ProvisioningPreferences_StackSetRegion = new List<System.String>(this.ProvisioningPreferences_StackSetRegion);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ServiceCatalog.Model.Tag>(this.Tag);
            }
            context.UpdateToken = this.UpdateToken;
            
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProvisionedProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.PathId != null)
            {
                request.PathId = cmdletContext.PathId;
            }
            if (cmdletContext.PathName != null)
            {
                request.PathName = cmdletContext.PathName;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProductName != null)
            {
                request.ProductName = cmdletContext.ProductName;
            }
            if (cmdletContext.ProvisionedProductId != null)
            {
                request.ProvisionedProductId = cmdletContext.ProvisionedProductId;
            }
            if (cmdletContext.ProvisionedProductName != null)
            {
                request.ProvisionedProductName = cmdletContext.ProvisionedProductName;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
            }
            if (cmdletContext.ProvisioningArtifactName != null)
            {
                request.ProvisioningArtifactName = cmdletContext.ProvisioningArtifactName;
            }
            if (cmdletContext.ProvisioningParameter != null)
            {
                request.ProvisioningParameters = cmdletContext.ProvisioningParameter;
            }
            
             // populate ProvisioningPreferences
            var requestProvisioningPreferencesIsNull = true;
            request.ProvisioningPreferences = new Amazon.ServiceCatalog.Model.UpdateProvisioningPreferences();
            List<System.String> requestProvisioningPreferences_provisioningPreferences_StackSetAccount = null;
            if (cmdletContext.ProvisioningPreferences_StackSetAccount != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetAccount = cmdletContext.ProvisioningPreferences_StackSetAccount;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetAccount != null)
            {
                request.ProvisioningPreferences.StackSetAccounts = requestProvisioningPreferences_provisioningPreferences_StackSetAccount;
                requestProvisioningPreferencesIsNull = false;
            }
            System.Int32? requestProvisioningPreferences_provisioningPreferences_StackSetFailureToleranceCount = null;
            if (cmdletContext.ProvisioningPreferences_StackSetFailureToleranceCount != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetFailureToleranceCount = cmdletContext.ProvisioningPreferences_StackSetFailureToleranceCount.Value;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetFailureToleranceCount != null)
            {
                request.ProvisioningPreferences.StackSetFailureToleranceCount = requestProvisioningPreferences_provisioningPreferences_StackSetFailureToleranceCount.Value;
                requestProvisioningPreferencesIsNull = false;
            }
            System.Int32? requestProvisioningPreferences_provisioningPreferences_StackSetFailureTolerancePercentage = null;
            if (cmdletContext.ProvisioningPreferences_StackSetFailureTolerancePercentage != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetFailureTolerancePercentage = cmdletContext.ProvisioningPreferences_StackSetFailureTolerancePercentage.Value;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetFailureTolerancePercentage != null)
            {
                request.ProvisioningPreferences.StackSetFailureTolerancePercentage = requestProvisioningPreferences_provisioningPreferences_StackSetFailureTolerancePercentage.Value;
                requestProvisioningPreferencesIsNull = false;
            }
            System.Int32? requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyCount = null;
            if (cmdletContext.ProvisioningPreferences_StackSetMaxConcurrencyCount != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyCount = cmdletContext.ProvisioningPreferences_StackSetMaxConcurrencyCount.Value;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyCount != null)
            {
                request.ProvisioningPreferences.StackSetMaxConcurrencyCount = requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyCount.Value;
                requestProvisioningPreferencesIsNull = false;
            }
            System.Int32? requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyPercentage = null;
            if (cmdletContext.ProvisioningPreferences_StackSetMaxConcurrencyPercentage != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyPercentage = cmdletContext.ProvisioningPreferences_StackSetMaxConcurrencyPercentage.Value;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyPercentage != null)
            {
                request.ProvisioningPreferences.StackSetMaxConcurrencyPercentage = requestProvisioningPreferences_provisioningPreferences_StackSetMaxConcurrencyPercentage.Value;
                requestProvisioningPreferencesIsNull = false;
            }
            Amazon.ServiceCatalog.StackSetOperationType requestProvisioningPreferences_provisioningPreferences_StackSetOperationType = null;
            if (cmdletContext.ProvisioningPreferences_StackSetOperationType != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetOperationType = cmdletContext.ProvisioningPreferences_StackSetOperationType;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetOperationType != null)
            {
                request.ProvisioningPreferences.StackSetOperationType = requestProvisioningPreferences_provisioningPreferences_StackSetOperationType;
                requestProvisioningPreferencesIsNull = false;
            }
            List<System.String> requestProvisioningPreferences_provisioningPreferences_StackSetRegion = null;
            if (cmdletContext.ProvisioningPreferences_StackSetRegion != null)
            {
                requestProvisioningPreferences_provisioningPreferences_StackSetRegion = cmdletContext.ProvisioningPreferences_StackSetRegion;
            }
            if (requestProvisioningPreferences_provisioningPreferences_StackSetRegion != null)
            {
                request.ProvisioningPreferences.StackSetRegions = requestProvisioningPreferences_provisioningPreferences_StackSetRegion;
                requestProvisioningPreferencesIsNull = false;
            }
             // determine if request.ProvisioningPreferences should be set to null
            if (requestProvisioningPreferencesIsNull)
            {
                request.ProvisioningPreferences = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProvisionedProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProvisionedProduct");
            try
            {
                return client.UpdateProvisionedProductAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String PathId { get; set; }
            public System.String PathName { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProductName { get; set; }
            public System.String ProvisionedProductId { get; set; }
            public System.String ProvisionedProductName { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public System.String ProvisioningArtifactName { get; set; }
            public List<Amazon.ServiceCatalog.Model.UpdateProvisioningParameter> ProvisioningParameter { get; set; }
            public List<System.String> ProvisioningPreferences_StackSetAccount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetFailureToleranceCount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetFailureTolerancePercentage { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyCount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyPercentage { get; set; }
            public Amazon.ServiceCatalog.StackSetOperationType ProvisioningPreferences_StackSetOperationType { get; set; }
            public List<System.String> ProvisioningPreferences_StackSetRegion { get; set; }
            public List<Amazon.ServiceCatalog.Model.Tag> Tag { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.UpdateProvisionedProductResponse, UpdateSCProvisionedProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecordDetail;
        }
        
    }
}
