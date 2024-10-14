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
    /// Returns the log events of a container of your Amazon Lightsail container service.
    /// 
    ///  
    /// <para>
    /// If your container service has more than one node (i.e., a scale greater than 1), then
    /// the log events that are returned for the specified container are merged from all nodes
    /// on your container service.
    /// </para><note><para>
    /// Container logs are retained for a certain amount of time. For more information, see
    /// <a href="https://docs.aws.amazon.com/general/latest/gr/lightsail.html">Amazon Lightsail
    /// endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LSContainerLog")]
    [OutputType("Amazon.Lightsail.Model.ContainerServiceLogEvent")]
    [AWSCmdlet("Calls the Amazon Lightsail GetContainerLog API operation.", Operation = new[] {"GetContainerLog"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetContainerLogResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContainerServiceLogEvent or Amazon.Lightsail.Model.GetContainerLogResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.ContainerServiceLogEvent objects.",
        "The service call response (type Amazon.Lightsail.Model.GetContainerLogResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSContainerLogCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container that is either running or previously ran on the container
        /// service for which to return a log.</para>
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
        public System.String ContainerName { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time interval for which to get log data.</para><para>Constraints:</para><ul><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use an end time of October 1, 2018, at 9 PM UTC, specify
        /// <c>1538427600</c> as the end time.</para></li></ul><para>You can convert a human-friendly time to Unix time format using a converter like <a href="https://www.epochconverter.com/">Epoch converter</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>The pattern to use to filter the returned log events to a specific term.</para><para>The following are a few examples of filter patterns that you can specify:</para><ul><li><para>To return all log events, specify a filter pattern of <c>""</c>.</para></li><li><para>To exclude log events that contain the <c>ERROR</c> term, and return all other log
        /// events, specify a filter pattern of <c>"-ERROR"</c>.</para></li><li><para>To return log events that contain the <c>ERROR</c> term, specify a filter pattern
        /// of <c>"ERROR"</c>.</para></li><li><para>To return log events that contain both the <c>ERROR</c> and <c>Exception</c> terms,
        /// specify a filter pattern of <c>"ERROR Exception"</c>.</para></li><li><para>To return log events that contain the <c>ERROR</c><i>or</i> the <c>Exception</c>
        /// term, specify a filter pattern of <c>"?ERROR ?Exception"</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the container service for which to get a container log.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time interval for which to get log data.</para><para>Constraints:</para><ul><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use a start time of October 1, 2018, at 8 PM UTC, specify
        /// <c>1538424000</c> as the start time.</para></li></ul><para>You can convert a human-friendly time to Unix time format using a converter like <a href="https://www.epochconverter.com/">Epoch converter</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of results from your request.</para><para>To get a page token, perform an initial <c>GetContainerLog</c> request. If your results
        /// are paginated, the response will return a next page token that you can specify as
        /// the page token in a subsequent request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'PageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-PageToken' to null for the first call then set the 'PageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetContainerLogResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetContainerLogResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogEvents";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of PageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetContainerLogResponse, GetLSContainerLogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerName = this.ContainerName;
            #if MODULAR
            if (this.ContainerName == null && ParameterWasBound(nameof(this.ContainerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTime = this.EndTime;
            context.FilterPattern = this.FilterPattern;
            context.PageToken = this.PageToken;
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Lightsail.Model.GetContainerLogRequest();
            
            if (cmdletContext.ContainerName != null)
            {
                request.ContainerName = cmdletContext.ContainerName;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.PageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lightsail.Model.GetContainerLogResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetContainerLogRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetContainerLog");
            try
            {
                #if DESKTOP
                return client.GetContainerLog(request);
                #elif CORECLR
                return client.GetContainerLogAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerName { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String PageToken { get; set; }
            public System.String ServiceName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetContainerLogResponse, GetLSContainerLogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogEvents;
        }
        
    }
}
