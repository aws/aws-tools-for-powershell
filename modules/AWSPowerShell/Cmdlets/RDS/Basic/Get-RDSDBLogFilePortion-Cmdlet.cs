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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Downloads all or a portion of the specified log file, up to 1 MB in size.
    /// 
    ///  
    /// <para>
    /// This command doesn't apply to RDS Custom.
    /// </para><note><para>
    /// This operation uses resources on database instances. Because of this, we recommend
    /// publishing database logs to CloudWatch and then using the GetLogEvents operation.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetLogEvents.html">GetLogEvents</a>
    /// in the <i>Amazon CloudWatch Logs API Reference</i>.
    /// </para></note><br/><br/>In the AWS.Tools.RDS module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSDBLogFilePortion")]
    [OutputType("Amazon.RDS.Model.DownloadDBLogFilePortionResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DownloadDBLogFilePortion API operation.", Operation = new[] {"DownloadDBLogFilePortion"}, SelectReturnType = typeof(Amazon.RDS.Model.DownloadDBLogFilePortionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DownloadDBLogFilePortionResponse",
        "This cmdlet returns an Amazon.RDS.Model.DownloadDBLogFilePortionResponse object containing multiple properties."
    )]
    public partial class GetRDSDBLogFilePortionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The customer-assigned name of the DB instance that contains the log files you want
        /// to list.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBInstance.</para></li></ul>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter LogFileName
        /// <summary>
        /// <para>
        /// <para>The name of the log file to be downloaded.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LogFileName { get; set; }
        #endregion
        
        #region Parameter NumberOfLines
        /// <summary>
        /// <para>
        /// <para>The number of lines to download. If the number of lines specified results in a file
        /// over 1 MB in size, the file is truncated at 1 MB in size.</para><para>If the NumberOfLines parameter is specified, then the block of lines returned can
        /// be from the beginning or the end of the log file, depending on the value of the Marker
        /// parameter.</para><ul><li><para>If neither Marker or NumberOfLines are specified, the entire log file is returned
        /// up to a maximum of 10000 lines, starting with the most recent log entries first.</para></li><li><para>If NumberOfLines is specified and Marker isn't specified, then the most recent lines
        /// from the end of the log file are returned.</para></li><li><para>If Marker is specified as "0", then the specified number of lines from the beginning
        /// of the log file are returned.</para></li><li><para>You can download the log file in blocks of lines by specifying the size of the block
        /// using the NumberOfLines parameter, and by specifying a value of "0" for the Marker
        /// parameter in your first request. Include the Marker value returned in the response
        /// as the Marker value for the next request, continuing until the AdditionalDataPending
        /// response element returns false.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumberOfLines { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token provided in the previous request or "0". If the Marker parameter
        /// is specified the response includes only records beyond the marker until the end of
        /// the file or up to NumberOfLines.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.RDS module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DownloadDBLogFilePortionResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DownloadDBLogFilePortionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DownloadDBLogFilePortionResponse, GetRDSDBLogFilePortionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogFileName = this.LogFileName;
            #if MODULAR
            if (this.LogFileName == null && ParameterWasBound(nameof(this.LogFileName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogFileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            context.NumberOfLines = this.NumberOfLines;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DownloadDBLogFilePortionRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.LogFileName != null)
            {
                request.LogFileName = cmdletContext.LogFileName;
            }
            if (cmdletContext.NumberOfLines != null)
            {
                request.NumberOfLines = cmdletContext.NumberOfLines.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.Marker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.DownloadDBLogFilePortionRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.LogFileName != null)
            {
                request.LogFileName = cmdletContext.LogFileName;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.NumberOfLines != null)
            {
                request.NumberOfLines = cmdletContext.NumberOfLines.Value;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DownloadDBLogFilePortionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DownloadDBLogFilePortionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DownloadDBLogFilePortion");
            try
            {
                #if DESKTOP
                return client.DownloadDBLogFilePortion(request);
                #elif CORECLR
                return client.DownloadDBLogFilePortionAsync(request).GetAwaiter().GetResult();
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.String LogFileName { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? NumberOfLines { get; set; }
            public System.Func<Amazon.RDS.Model.DownloadDBLogFilePortionResponse, GetRDSDBLogFilePortionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
