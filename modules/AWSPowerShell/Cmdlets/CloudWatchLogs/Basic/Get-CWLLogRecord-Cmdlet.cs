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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Retrieves all of the fields and values of a single log event. All fields are retrieved,
    /// even if the original query that produced the <code>logRecordPointer</code> retrieved
    /// only a subset of fields. Fields are returned as field name/field value pairs.
    /// 
    ///  
    /// <para>
    /// The full unparsed log event is returned within <code>@message</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogRecord")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs GetLogRecord API operation.", Operation = new[] {"GetLogRecord"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.GetLogRecordResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.GetLogRecordResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.GetLogRecordResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWLLogRecordCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter LogRecordPointer
        /// <summary>
        /// <para>
        /// <para>The pointer corresponding to the log event record you want to retrieve. You get this
        /// from the response of a <code>GetQueryResults</code> operation. In that response, the
        /// value of the <code>@ptr</code> field for a log event is the value to use as <code>logRecordPointer</code>
        /// to retrieve that complete log event record.</para>
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
        public System.String LogRecordPointer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogRecord'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.GetLogRecordResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.GetLogRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogRecord";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogRecordPointer parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogRecordPointer' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogRecordPointer' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.GetLogRecordResponse, GetCWLLogRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogRecordPointer;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LogRecordPointer = this.LogRecordPointer;
            #if MODULAR
            if (this.LogRecordPointer == null && ParameterWasBound(nameof(this.LogRecordPointer)))
            {
                WriteWarning("You are passing $null as a value for parameter LogRecordPointer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.GetLogRecordRequest();
            
            if (cmdletContext.LogRecordPointer != null)
            {
                request.LogRecordPointer = cmdletContext.LogRecordPointer;
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
        
        private Amazon.CloudWatchLogs.Model.GetLogRecordResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.GetLogRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "GetLogRecord");
            try
            {
                #if DESKTOP
                return client.GetLogRecord(request);
                #elif CORECLR
                return client.GetLogRecordAsync(request).GetAwaiter().GetResult();
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
            public System.String LogRecordPointer { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.GetLogRecordResponse, GetCWLLogRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogRecord;
        }
        
    }
}
