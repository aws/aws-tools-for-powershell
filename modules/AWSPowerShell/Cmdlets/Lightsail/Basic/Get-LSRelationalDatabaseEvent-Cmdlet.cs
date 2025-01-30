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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns a list of events for a specific database in Amazon Lightsail.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LSRelationalDatabaseEvent")]
    [OutputType("Amazon.Lightsail.Model.RelationalDatabaseEvent")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRelationalDatabaseEvents API operation.", Operation = new[] {"GetRelationalDatabaseEvents"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.RelationalDatabaseEvent or Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.RelationalDatabaseEvent objects.",
        "The service call response (type Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSRelationalDatabaseEventCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DurationInMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes in the past from which to retrieve events. For example, to get
        /// all events from the past 2 hours, enter 120.</para><para>Default: <c>60</c></para><para>The minimum is 1 and the maximum is 14 days (20160 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationInMinutes")]
        public System.Int32? DurationInMinute { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database from which to get events.</para>
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
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of results from your request.</para><para>To get a page token, perform an initial <c>GetRelationalDatabaseEvents</c> request.
        /// If your results are paginated, the response will return a next page token that you
        /// can specify as the page token in a subsequent request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelationalDatabaseEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelationalDatabaseEvents";
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse, GetLSRelationalDatabaseEventCmdlet>(Select) ??
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
            context.DurationInMinute = this.DurationInMinute;
            context.PageToken = this.PageToken;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Lightsail.Model.GetRelationalDatabaseEventsRequest();
            
            if (cmdletContext.DurationInMinute != null)
            {
                request.DurationInMinutes = cmdletContext.DurationInMinute.Value;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
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
        
        private Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRelationalDatabaseEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRelationalDatabaseEvents");
            try
            {
                #if DESKTOP
                return client.GetRelationalDatabaseEvents(request);
                #elif CORECLR
                return client.GetRelationalDatabaseEventsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationInMinute { get; set; }
            public System.String PageToken { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetRelationalDatabaseEventsResponse, GetLSRelationalDatabaseEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelationalDatabaseEvents;
        }
        
    }
}
