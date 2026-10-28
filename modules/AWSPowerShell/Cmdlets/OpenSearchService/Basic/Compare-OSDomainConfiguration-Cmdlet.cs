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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Compares the metadata of two domains and reports where they differ. Use this operation
    /// to check that a secondary domain is configured consistently with its primary before
    /// you rely on it, because replication copies index data but does not copy domain metadata
    /// such as index templates, ingest pipelines, or security roles.
    /// 
    ///  
    /// <para>
    /// You choose which categories to compare. The response reports, for each category, how
    /// many items match, how many exist on only one domain, and which fields diverge.
    /// </para>
    /// </summary>
    [Cmdlet("Compare", "OSDomainConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service CompareDomainConfiguration API operation.", Operation = new[] {"CompareDomainConfiguration"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse object containing multiple properties."
    )]
    public partial class CompareOSDomainConfigurationCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>The metadata categories to compare. At least one is required, and only the categories
        /// you name are read and returned.</para><ul><li><para><c>aliases</c></para></li><li><para><c>alerting_monitors</c></para></li><li><para><c>cluster_settings</c></para></li><li><para><c>component_templates</c></para></li><li><para><c>ingest_pipelines</c></para></li><li><para><c>ism_policies</c> — index state management policies</para></li><li><para><c>security_action_groups</c></para></li><li><para><c>security_internal_users</c></para></li><li><para><c>security_role_mappings</c></para></li><li><para><c>security_roles</c></para></li><li><para><c>templates</c> — index templates</para></li></ul><para>The set of categories grows over time, so this list is not fixed. A category the service
        /// does not recognise is rejected with the supported categories named in the error message.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Categories")]
        public System.String[] Category { get; set; }
        #endregion
        
        #region Parameter SourceDomainArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the domain to compare from.</para>
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
        public System.String SourceDomainArn { get; set; }
        #endregion
        
        #region Parameter TargetDomainArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the domain to compare against.</para>
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
        public System.String TargetDomainArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.SourceDomainArn),
                nameof(this.TargetDomainArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Compare-OSDomainConfiguration (CompareDomainConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse, CompareOSDomainConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Category != null)
            {
                context.Category = new List<System.String>(this.Category);
            }
            #if MODULAR
            if (this.Category == null && ParameterWasBound(nameof(this.Category)))
            {
                WriteWarning("You are passing $null as a value for parameter Category which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDomainArn = this.SourceDomainArn;
            #if MODULAR
            if (this.SourceDomainArn == null && ParameterWasBound(nameof(this.SourceDomainArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDomainArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDomainArn = this.TargetDomainArn;
            #if MODULAR
            if (this.TargetDomainArn == null && ParameterWasBound(nameof(this.TargetDomainArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDomainArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.CompareDomainConfigurationRequest();
            
            if (cmdletContext.Category != null)
            {
                request.Categories = cmdletContext.Category;
            }
            if (cmdletContext.SourceDomainArn != null)
            {
                request.SourceDomainArn = cmdletContext.SourceDomainArn;
            }
            if (cmdletContext.TargetDomainArn != null)
            {
                request.TargetDomainArn = cmdletContext.TargetDomainArn;
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
        
        private Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.CompareDomainConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "CompareDomainConfiguration");
            try
            {
                return client.CompareDomainConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Category { get; set; }
            public System.String SourceDomainArn { get; set; }
            public System.String TargetDomainArn { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.CompareDomainConfigurationResponse, CompareOSDomainConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
