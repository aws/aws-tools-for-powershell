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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Provisions the specified product. 
    /// 
    ///  
    /// <para>
    ///  A provisioned product is a resourced instance of a product. For example, provisioning
    /// a product that's based on an CloudFormation template launches an CloudFormation stack
    /// and its underlying resources. You can check the status of this request using <a>DescribeRecord</a>.
    /// 
    /// </para><para>
    ///  If the request contains a tag key with an empty list of values, there's a tag conflict
    /// for that key. Don't include conflicted keys as tags, or this will cause the error
    /// "Parameter validation failed: Missing required parameter in Tags[<i>N</i>]:<i>Value</i>".
    /// 
    /// </para><note><para>
    ///  When provisioning a product that's been added to a portfolio, you must grant your
    /// user, group, or role access to the portfolio. For more information, see <a href="https://docs.aws.amazon.com/servicecatalog/latest/adminguide/catalogs_portfolios_users.html">Granting
    /// users access</a> in the <i>Service Catalog User Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SCProvisionedProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog ProvisionProduct API operation.", Operation = new[] {"ProvisionProduct"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.ProvisionProductResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail or Amazon.ServiceCatalog.Model.ProvisionProductResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.RecordDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.ProvisionProductResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCProvisionedProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter NotificationArn
        /// <summary>
        /// <para>
        /// <para>Passed to CloudFormation. The SNS topic ARNs to which to publish stack-related events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationArns")]
        public System.String[] NotificationArn { get; set; }
        #endregion
        
        #region Parameter PathId
        /// <summary>
        /// <para>
        /// <para>The path identifier of the product. This value is optional if the product has a default
        /// path, and required if the product has more than one path. To list the paths for a
        /// product, use <a>ListLaunchPaths</a>. You must provide the name or ID, but not both.</para>
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
        /// <para>The product identifier. You must provide the name or ID, but not both.</para>
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
        
        #region Parameter ProvisionedProductName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the provisioned product. This value must be unique for the
        /// Amazon Web Services account and cannot be updated after the product is provisioned.</para>
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
        public System.String ProvisionedProductName { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact. You must provide the name or ID, but
        /// not both.</para>
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
        /// <para>Parameters specified by the administrator that are required for provisioning the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningParameters")]
        public Amazon.ServiceCatalog.Model.ProvisioningParameter[] ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter ProvisionToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token that uniquely identifies the provisioning request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisionToken { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetAccount
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Web Services accounts where the provisioned product will be available.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>The specified accounts should be within the list of accounts from the <code>STACKSET</code>
        /// constraint. To get the list of accounts in the <code>STACKSET</code> constraint, use
        /// the <code>DescribeProvisioningParameters</code> operation.</para><para>If no values are specified, the default value is all acounts from the <code>STACKSET</code>
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
        /// Service Catalog doesn't attempt the operation in any subsequent Regions.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>Conditional: You must specify either <code>StackSetFailureToleranceCount</code> or
        /// <code>StackSetFailureTolerancePercentage</code>, but not both.</para><para>The default value is <code>0</code> if no value is specified.</para>
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
        /// Catalog rounds down to the next whole number.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>Conditional: You must specify either <code>StackSetFailureToleranceCount</code> or
        /// <code>StackSetFailureTolerancePercentage</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetFailureTolerancePercentage { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetMaxConcurrencyCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of accounts in which to perform this operation at one time. This
        /// is dependent on the value of <code>StackSetFailureToleranceCount</code>. <code>StackSetMaxConcurrentCount</code>
        /// is at most one more than the <code>StackSetFailureToleranceCount</code>.</para><para>Note that this setting lets you specify the maximum for operations. For large deployments,
        /// under certain circumstances the actual number of accounts acted upon concurrently
        /// may be lower due to service throttling.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>Conditional: You must specify either <code>StackSetMaxConcurrentCount</code> or <code>StackSetMaxConcurrentPercentage</code>,
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
        /// down would result is zero. In this case, Service Catalog sets the number as <code>1</code>
        /// instead.</para><para>Note that this setting lets you specify the maximum for operations. For large deployments,
        /// under certain circumstances the actual number of accounts acted upon concurrently
        /// may be lower due to service throttling.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>Conditional: You must specify either <code>StackSetMaxConcurrentCount</code> or <code>StackSetMaxConcurrentPercentage</code>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyPercentage { get; set; }
        #endregion
        
        #region Parameter ProvisioningPreferences_StackSetRegion
        /// <summary>
        /// <para>
        /// <para>One or more Amazon Web Services Regions where the provisioned product will be available.</para><para>Applicable only to a <code>CFN_STACKSET</code> provisioned product type.</para><para>The specified Regions should be within the list of Regions from the <code>STACKSET</code>
        /// constraint. To get the list of Regions in the <code>STACKSET</code> constraint, use
        /// the <code>DescribeProvisioningParameters</code> operation.</para><para>If no values are specified, the default value is all Regions from the <code>STACKSET</code>
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
        /// <para>One or more tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ServiceCatalog.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecordDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.ProvisionProductResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.ProvisionProductResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecordDetail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProvisionedProductName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProvisionedProductName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProvisionedProductName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProvisionedProductName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCProvisionedProduct (ProvisionProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.ProvisionProductResponse, NewSCProvisionedProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProvisionedProductName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.NotificationArn != null)
            {
                context.NotificationArn = new List<System.String>(this.NotificationArn);
            }
            context.PathId = this.PathId;
            context.PathName = this.PathName;
            context.ProductId = this.ProductId;
            context.ProductName = this.ProductName;
            context.ProvisionedProductName = this.ProvisionedProductName;
            #if MODULAR
            if (this.ProvisionedProductName == null && ParameterWasBound(nameof(this.ProvisionedProductName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedProductName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            context.ProvisioningArtifactName = this.ProvisioningArtifactName;
            if (this.ProvisioningParameter != null)
            {
                context.ProvisioningParameter = new List<Amazon.ServiceCatalog.Model.ProvisioningParameter>(this.ProvisioningParameter);
            }
            if (this.ProvisioningPreferences_StackSetAccount != null)
            {
                context.ProvisioningPreferences_StackSetAccount = new List<System.String>(this.ProvisioningPreferences_StackSetAccount);
            }
            context.ProvisioningPreferences_StackSetFailureToleranceCount = this.ProvisioningPreferences_StackSetFailureToleranceCount;
            context.ProvisioningPreferences_StackSetFailureTolerancePercentage = this.ProvisioningPreferences_StackSetFailureTolerancePercentage;
            context.ProvisioningPreferences_StackSetMaxConcurrencyCount = this.ProvisioningPreferences_StackSetMaxConcurrencyCount;
            context.ProvisioningPreferences_StackSetMaxConcurrencyPercentage = this.ProvisioningPreferences_StackSetMaxConcurrencyPercentage;
            if (this.ProvisioningPreferences_StackSetRegion != null)
            {
                context.ProvisioningPreferences_StackSetRegion = new List<System.String>(this.ProvisioningPreferences_StackSetRegion);
            }
            context.ProvisionToken = this.ProvisionToken;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ServiceCatalog.Model.Tag>(this.Tag);
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
            var request = new Amazon.ServiceCatalog.Model.ProvisionProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.NotificationArn != null)
            {
                request.NotificationArns = cmdletContext.NotificationArn;
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
            request.ProvisioningPreferences = new Amazon.ServiceCatalog.Model.ProvisioningPreferences();
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
            if (cmdletContext.ProvisionToken != null)
            {
                request.ProvisionToken = cmdletContext.ProvisionToken;
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
        
        private Amazon.ServiceCatalog.Model.ProvisionProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.ProvisionProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "ProvisionProduct");
            try
            {
                #if DESKTOP
                return client.ProvisionProduct(request);
                #elif CORECLR
                return client.ProvisionProductAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public List<System.String> NotificationArn { get; set; }
            public System.String PathId { get; set; }
            public System.String PathName { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProductName { get; set; }
            public System.String ProvisionedProductName { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public System.String ProvisioningArtifactName { get; set; }
            public List<Amazon.ServiceCatalog.Model.ProvisioningParameter> ProvisioningParameter { get; set; }
            public List<System.String> ProvisioningPreferences_StackSetAccount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetFailureToleranceCount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetFailureTolerancePercentage { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyCount { get; set; }
            public System.Int32? ProvisioningPreferences_StackSetMaxConcurrencyPercentage { get; set; }
            public List<System.String> ProvisioningPreferences_StackSetRegion { get; set; }
            public System.String ProvisionToken { get; set; }
            public List<Amazon.ServiceCatalog.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.ProvisionProductResponse, NewSCProvisionedProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecordDetail;
        }
        
    }
}
