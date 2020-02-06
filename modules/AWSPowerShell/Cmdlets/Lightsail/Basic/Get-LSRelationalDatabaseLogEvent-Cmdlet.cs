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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns a list of log events for a database in Amazon Lightsail.
    /// </summary>
    [Cmdlet("Get", "LSRelationalDatabaseLogEvent")]
    [OutputType("Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRelationalDatabaseLogEvents API operation.", Operation = new[] {"GetRelationalDatabaseLogEvents"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSRelationalDatabaseLogEventCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time interval from which to get log events.</para><para>Constraints:</para><ul><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use an end time of October 1, 2018, at 8 PM UTC, then
        /// you input <code>1538424000</code> as the end time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para><para>Use the <code>get relational database log streams</code> operation to get a list of
        /// available log streams.</para>
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
        public System.String LogStreamName { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database for which to get log events.</para>
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
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter StartFromHead
        /// <summary>
        /// <para>
        /// <para>Parameter to specify if the log should start from head or tail. If <code>true</code>
        /// is specified, the log event starts from the head of the log. If <code>false</code>
        /// is specified, the log event starts from the tail of the log.</para><note><para>For PostgreSQL, the default value of <code>false</code> is the only option available.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StartFromHead { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time interval from which to get log events.</para><para>Constraints:</para><ul><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use a start time of October 1, 2018, at 8 PM UTC, then
        /// you input <code>1538424000</code> as the start time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next or previous page of results from your request.</para><para>To get a page token, perform an initial <code>GetRelationalDatabaseLogEvents</code>
        /// request. If your results are paginated, the response will return a next forward token
        /// and/or next backward token that you can specify as the page token in a subsequent
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RelationalDatabaseName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RelationalDatabaseName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RelationalDatabaseName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse, GetLSRelationalDatabaseLogEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RelationalDatabaseName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            context.LogStreamName = this.LogStreamName;
            #if MODULAR
            if (this.LogStreamName == null && ParameterWasBound(nameof(this.LogStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PageToken = this.PageToken;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartFromHead = this.StartFromHead;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.PageToken != null)
            {
                request.PageToken = cmdletContext.PageToken;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            if (cmdletContext.StartFromHead != null)
            {
                request.StartFromHead = cmdletContext.StartFromHead.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRelationalDatabaseLogEvents");
            try
            {
                #if DESKTOP
                return client.GetRelationalDatabaseLogEvents(request);
                #elif CORECLR
                return client.GetRelationalDatabaseLogEventsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String LogStreamName { get; set; }
            public System.String PageToken { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Boolean? StartFromHead { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse, GetLSRelationalDatabaseLogEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
