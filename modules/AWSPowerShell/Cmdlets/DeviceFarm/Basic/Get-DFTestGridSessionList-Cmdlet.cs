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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Retrieves a list of sessions for a <a>TestGridProject</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DFTestGridSessionList")]
    [OutputType("Amazon.DeviceFarm.Model.TestGridSession")]
    [AWSCmdlet("Calls the AWS Device Farm ListTestGridSessions API operation.", Operation = new[] {"ListTestGridSessions"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.ListTestGridSessionsResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.TestGridSession or Amazon.DeviceFarm.Model.ListTestGridSessionsResponse",
        "This cmdlet returns a collection of Amazon.DeviceFarm.Model.TestGridSession objects.",
        "The service call response (type Amazon.DeviceFarm.Model.ListTestGridSessionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDFTestGridSessionListCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>Return only sessions created after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>Return only sessions created before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter EndTimeAfter
        /// <summary>
        /// <para>
        /// <para>Return only sessions that ended after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTimeAfter { get; set; }
        #endregion
        
        #region Parameter EndTimeBefore
        /// <summary>
        /// <para>
        /// <para>Return only sessions that ended before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTimeBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Return only this many results at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>ARN of a <a>TestGridProject</a>.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Return only sessions in this state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestGridSessionStatus")]
        public Amazon.DeviceFarm.TestGridSessionStatus Status { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestGridSessions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.ListTestGridSessionsResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.ListTestGridSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestGridSessions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.ListTestGridSessionsResponse, GetDFTestGridSessionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.EndTimeAfter = this.EndTimeAfter;
            context.EndTimeBefore = this.EndTimeBefore;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            
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
            var request = new Amazon.DeviceFarm.Model.ListTestGridSessionsRequest();
            
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.EndTimeAfter != null)
            {
                request.EndTimeAfter = cmdletContext.EndTimeAfter.Value;
            }
            if (cmdletContext.EndTimeBefore != null)
            {
                request.EndTimeBefore = cmdletContext.EndTimeBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResult = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.DeviceFarm.Model.ListTestGridSessionsResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.ListTestGridSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "ListTestGridSessions");
            try
            {
                #if DESKTOP
                return client.ListTestGridSessions(request);
                #elif CORECLR
                return client.ListTestGridSessionsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? CreationTimeAfter { get; set; }
            public System.DateTime? CreationTimeBefore { get; set; }
            public System.DateTime? EndTimeAfter { get; set; }
            public System.DateTime? EndTimeBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProjectArn { get; set; }
            public Amazon.DeviceFarm.TestGridSessionStatus Status { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.ListTestGridSessionsResponse, GetDFTestGridSessionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestGridSessions;
        }
        
    }
}
