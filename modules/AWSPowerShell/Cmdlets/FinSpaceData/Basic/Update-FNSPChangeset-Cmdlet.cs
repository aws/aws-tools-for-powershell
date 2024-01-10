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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Updates a FinSpace Changeset.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "FNSPChangeset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FinSpaceData.Model.UpdateChangesetResponse")]
    [AWSCmdlet("Calls the FinSpace Public API UpdateChangeset API operation.", Operation = new[] {"UpdateChangeset"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.UpdateChangesetResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.UpdateChangesetResponse",
        "This cmdlet returns an Amazon.FinSpaceData.Model.UpdateChangesetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class UpdateFNSPChangesetCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangesetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Changeset to update.</para>
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
        public System.String ChangesetId { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the FinSpace Dataset in which the Changeset is created.</para>
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
        /// data from an Amazon S3 Bucket using the FinSpace API</a>section.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.UpdateChangesetResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.UpdateChangesetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FNSPChangeset (UpdateChangeset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.UpdateChangesetResponse, UpdateFNSPChangesetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangesetId = this.ChangesetId;
            #if MODULAR
            if (this.ChangesetId == null && ParameterWasBound(nameof(this.ChangesetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangesetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
                    context.FormatParam.Add((String)hashKey, (String)(this.FormatParam[hashKey]));
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
                    context.SourceParam.Add((String)hashKey, (String)(this.SourceParam[hashKey]));
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
            var request = new Amazon.FinSpaceData.Model.UpdateChangesetRequest();
            
            if (cmdletContext.ChangesetId != null)
            {
                request.ChangesetId = cmdletContext.ChangesetId;
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
        
        private Amazon.FinSpaceData.Model.UpdateChangesetResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.UpdateChangesetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "UpdateChangeset");
            try
            {
                #if DESKTOP
                return client.UpdateChangeset(request);
                #elif CORECLR
                return client.UpdateChangesetAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangesetId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetId { get; set; }
            public Dictionary<System.String, System.String> FormatParam { get; set; }
            public Dictionary<System.String, System.String> SourceParam { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.UpdateChangesetResponse, UpdateFNSPChangesetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
