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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Imports resources to Resilience Hub application draft version from different input
    /// sources. For more information about the input sources supported by Resilience Hub,
    /// see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/discover-structure.html">Discover
    /// the structure and describe your Resilience Hub application</a>.
    /// </summary>
    [Cmdlet("Import", "RESHResourcesToDraftAppVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub ImportResourcesToDraftAppVersion API operation.", Operation = new[] {"ImportResourcesToDraftAppVersion"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse object containing multiple properties."
    )]
    public partial class ImportRESHResourcesToDraftAppVersionCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<c>partition</c>:resiliencehub:<c>region</c>:<c>account</c>:app/<c>app-id</c>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
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
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter EksSource
        /// <summary>
        /// <para>
        /// <para>The input sources of the Amazon Elastic Kubernetes Service resources you need to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksSources")]
        public Amazon.ResilienceHub.Model.EksSource[] EksSource { get; set; }
        #endregion
        
        #region Parameter ImportStrategy
        /// <summary>
        /// <para>
        /// <para>The import strategy you would like to set to import resources into Resilience Hub
        /// application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ResilienceHub.ResourceImportStrategyType")]
        public Amazon.ResilienceHub.ResourceImportStrategyType ImportStrategy { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) for the resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceArns")]
        public System.String[] SourceArn { get; set; }
        #endregion
        
        #region Parameter TerraformSource
        /// <summary>
        /// <para>
        /// <para> A list of terraform file s3 URLs you need to import. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerraformSources")]
        public Amazon.ResilienceHub.Model.TerraformSource[] TerraformSource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-RESHResourcesToDraftAppVersion (ImportResourcesToDraftAppVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse, ImportRESHResourcesToDraftAppVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppArn = this.AppArn;
            #if MODULAR
            if (this.AppArn == null && ParameterWasBound(nameof(this.AppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EksSource != null)
            {
                context.EksSource = new List<Amazon.ResilienceHub.Model.EksSource>(this.EksSource);
            }
            context.ImportStrategy = this.ImportStrategy;
            if (this.SourceArn != null)
            {
                context.SourceArn = new List<System.String>(this.SourceArn);
            }
            if (this.TerraformSource != null)
            {
                context.TerraformSource = new List<Amazon.ResilienceHub.Model.TerraformSource>(this.TerraformSource);
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
            var request = new Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.EksSource != null)
            {
                request.EksSources = cmdletContext.EksSource;
            }
            if (cmdletContext.ImportStrategy != null)
            {
                request.ImportStrategy = cmdletContext.ImportStrategy;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArns = cmdletContext.SourceArn;
            }
            if (cmdletContext.TerraformSource != null)
            {
                request.TerraformSources = cmdletContext.TerraformSource;
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
        
        private Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "ImportResourcesToDraftAppVersion");
            try
            {
                return client.ImportResourcesToDraftAppVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public List<Amazon.ResilienceHub.Model.EksSource> EksSource { get; set; }
            public Amazon.ResilienceHub.ResourceImportStrategyType ImportStrategy { get; set; }
            public List<System.String> SourceArn { get; set; }
            public List<Amazon.ResilienceHub.Model.TerraformSource> TerraformSource { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.ImportResourcesToDraftAppVersionResponse, ImportRESHResourcesToDraftAppVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
