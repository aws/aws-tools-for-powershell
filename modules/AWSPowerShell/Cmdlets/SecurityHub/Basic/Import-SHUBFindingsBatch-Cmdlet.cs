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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Imports security findings generated from an integrated third-party product into Security
    /// Hub. This action is requested by the integrated product to import its findings into
    /// Security Hub.
    /// 
    ///  
    /// <para>
    /// The maximum allowed size for a finding is 240 Kb. An error is returned for any finding
    /// larger than 240 Kb.
    /// </para><para>
    /// After a finding is created, <code>BatchImportFindings</code> cannot be used to update
    /// the following finding fields and objects, which Security Hub customers use to manage
    /// their investigation workflow.
    /// </para><ul><li><para><code>Note</code></para></li><li><para><code>UserDefinedFields</code></para></li><li><para><code>VerificationState</code></para></li><li><para><code>Workflow</code></para></li></ul><para><code>BatchImportFindings</code> can be used to update the following finding fields
    /// and objects only if they have not been updated using <code>BatchUpdateFindings</code>.
    /// After they are updated using <code>BatchUpdateFindings</code>, these fields cannot
    /// be updated using <code>BatchImportFindings</code>.
    /// </para><ul><li><para><code>Confidence</code></para></li><li><para><code>Criticality</code></para></li><li><para><code>RelatedFindings</code></para></li><li><para><code>Severity</code></para></li><li><para><code>Types</code></para></li></ul>
    /// </summary>
    [Cmdlet("Import", "SHUBFindingsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.BatchImportFindingsResponse")]
    [AWSCmdlet("Calls the AWS Security Hub BatchImportFindings API operation.", Operation = new[] {"BatchImportFindings"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchImportFindingsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchImportFindingsResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchImportFindingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportSHUBFindingsBatchCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter Finding
        /// <summary>
        /// <para>
        /// <para>A list of findings to import. To successfully import a finding, it must follow the
        /// <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/securityhub-findings-format.html">AWS
        /// Security Finding Format</a>. Maximum of 100 findings per request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Findings")]
        public Amazon.SecurityHub.Model.AwsSecurityFinding[] Finding { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchImportFindingsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchImportFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Finding parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Finding' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Finding' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Finding), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-SHUBFindingsBatch (BatchImportFindings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchImportFindingsResponse, ImportSHUBFindingsBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Finding;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Finding != null)
            {
                context.Finding = new List<Amazon.SecurityHub.Model.AwsSecurityFinding>(this.Finding);
            }
            #if MODULAR
            if (this.Finding == null && ParameterWasBound(nameof(this.Finding)))
            {
                WriteWarning("You are passing $null as a value for parameter Finding which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.BatchImportFindingsRequest();
            
            if (cmdletContext.Finding != null)
            {
                request.Findings = cmdletContext.Finding;
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
        
        private Amazon.SecurityHub.Model.BatchImportFindingsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchImportFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchImportFindings");
            try
            {
                #if DESKTOP
                return client.BatchImportFindings(request);
                #elif CORECLR
                return client.BatchImportFindingsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.AwsSecurityFinding> Finding { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchImportFindingsResponse, ImportSHUBFindingsBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
