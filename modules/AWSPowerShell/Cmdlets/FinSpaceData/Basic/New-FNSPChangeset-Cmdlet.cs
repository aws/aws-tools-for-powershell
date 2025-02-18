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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Creates a new Changeset in a FinSpace Dataset.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "FNSPChangeset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FinSpaceData.Model.CreateChangesetResponse")]
    [AWSCmdlet("Calls the FinSpace Public API CreateChangeset API operation.", Operation = new[] {"CreateChangeset"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.CreateChangesetResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.CreateChangesetResponse",
        "This cmdlet returns an Amazon.FinSpaceData.Model.CreateChangesetResponse object containing multiple properties."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class NewFNSPChangesetCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeType
        /// <summary>
        /// <para>
        /// <para>The option to indicate how a Changeset will be applied to a Dataset.</para><ul><li><para><c>REPLACE</c> – Changeset will be considered as a replacement to all prior loaded
        /// Changesets.</para></li><li><para><c>APPEND</c> – Changeset will be considered as an addition to the end of all prior
        /// loaded Changesets.</para></li><li><para><c>MODIFY</c> – Changeset is considered as a replacement to a specific prior ingested
        /// Changeset.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FinSpaceData.ChangeType")]
        public Amazon.FinSpaceData.ChangeType ChangeType { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the FinSpace Dataset where the Changeset will be created.
        /// </para>
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter FormatParam
        /// <summary>
        /// <para>
        /// <para>Options that define the structure of the source file(s) including the format type
        /// (<c>formatType</c>), header row (<c>withHeader</c>), data separation character (<c>separator</c>)
        /// and the type of compression (<c>compression</c>). </para><para><c>formatType</c> is a required attribute and can have the following values: </para><ul><li><para><c>PARQUET</c> – Parquet source file format.</para></li><li><para><c>CSV</c> – CSV source file format.</para></li><li><para><c>JSON</c> – JSON source file format.</para></li><li><para><c>XML</c> – XML source file format.</para></li></ul><para>Here is an example of how you could specify the <c>formatParams</c>:</para><para><c> "formatParams": { "formatType": "CSV", "withHeader": "true", "separator": ",",
        /// "compression":"None" } </c></para><para>Note that if you only provide <c>formatType</c> as <c>CSV</c>, the rest of the attributes
        /// will automatically default to CSV values as following:</para><para><c> { "withHeader": "true", "separator": "," } </c></para><para> For more information about supported file formats, see <a href="https://docs.aws.amazon.com/finspace/latest/userguide/supported-data-types.html">Supported
        /// Data Types and File Formats</a> in the FinSpace User Guide.</para>
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
        [Alias("FormatParams")]
        public System.Collections.Hashtable FormatParam { get; set; }
        #endregion
        
        #region Parameter SourceParam
        /// <summary>
        /// <para>
        /// <para>Options that define the location of the data being ingested (<c>s3SourcePath</c>)
        /// and the source of the changeset (<c>sourceType</c>).</para><para>Both <c>s3SourcePath</c> and <c>sourceType</c> are required attributes.</para><para>Here is an example of how you could specify the <c>sourceParams</c>:</para><para><c> "sourceParams": { "s3SourcePath": "s3://finspace-landing-us-east-2-bk7gcfvitndqa6ebnvys4d/scratch/wr5hh8pwkpqqkxa4sxrmcw/ingestion/equity.csv",
        /// "sourceType": "S3" } </c></para><para>The S3 path that you specify must allow the FinSpace role access. To do that, you
        /// first need to configure the IAM policy on S3 bucket. For more information, see <a href="https://docs.aws.amazon.com/finspace/latest/data-api/fs-using-the-finspace-api.html#access-s3-buckets">Loading
        /// data from an Amazon S3 Bucket using the FinSpace API</a> section.</para>
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
        [Alias("SourceParams")]
        public System.Collections.Hashtable SourceParam { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.CreateChangesetResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.CreateChangesetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FNSPChangeset (CreateChangeset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.CreateChangesetResponse, NewFNSPChangesetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeType = this.ChangeType;
            #if MODULAR
            if (this.ChangeType == null && ParameterWasBound(nameof(this.ChangeType)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FormatParam != null)
            {
                context.FormatParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FormatParam.Keys)
                {
                    context.FormatParam.Add((String)hashKey, (System.String)(this.FormatParam[hashKey]));
                }
            }
            #if MODULAR
            if (this.FormatParam == null && ParameterWasBound(nameof(this.FormatParam)))
            {
                WriteWarning("You are passing $null as a value for parameter FormatParam which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceParam != null)
            {
                context.SourceParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceParam.Keys)
                {
                    context.SourceParam.Add((String)hashKey, (System.String)(this.SourceParam[hashKey]));
                }
            }
            #if MODULAR
            if (this.SourceParam == null && ParameterWasBound(nameof(this.SourceParam)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceParam which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FinSpaceData.Model.CreateChangesetRequest();
            
            if (cmdletContext.ChangeType != null)
            {
                request.ChangeType = cmdletContext.ChangeType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.FormatParam != null)
            {
                request.FormatParams = cmdletContext.FormatParam;
            }
            if (cmdletContext.SourceParam != null)
            {
                request.SourceParams = cmdletContext.SourceParam;
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
        
        private Amazon.FinSpaceData.Model.CreateChangesetResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.CreateChangesetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "CreateChangeset");
            try
            {
                return client.CreateChangesetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.FinSpaceData.ChangeType ChangeType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetId { get; set; }
            public Dictionary<System.String, System.String> FormatParam { get; set; }
            public Dictionary<System.String, System.String> SourceParam { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.CreateChangesetResponse, NewFNSPChangesetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
