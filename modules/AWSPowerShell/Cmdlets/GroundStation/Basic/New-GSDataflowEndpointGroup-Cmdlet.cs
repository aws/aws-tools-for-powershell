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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Creates a <c>DataflowEndpoint</c> group containing the specified list of <c>DataflowEndpoint</c>
    /// objects.
    /// 
    ///  
    /// <para>
    /// The <c>name</c> field in each endpoint is used in your mission profile <c>DataflowEndpointConfig</c>
    /// to specify which endpoints to use during a contact.
    /// </para><para>
    /// When a contact uses multiple <c>DataflowEndpointConfig</c> objects, each <c>Config</c>
    /// must match a <c>DataflowEndpoint</c> in the same group.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GSDataflowEndpointGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station CreateDataflowEndpointGroup API operation.", Operation = new[] {"CreateDataflowEndpointGroup"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGSDataflowEndpointGroupCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactPostPassDurationSecond
        /// <summary>
        /// <para>
        /// <para>Amount of time, in seconds, after a contact ends that the Ground Station Dataflow
        /// Endpoint Group will be in a <c>POSTPASS</c> state. A Ground Station Dataflow Endpoint
        /// Group State Change event will be emitted when the Dataflow Endpoint Group enters and
        /// exits the <c>POSTPASS</c> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContactPostPassDurationSeconds")]
        public System.Int32? ContactPostPassDurationSecond { get; set; }
        #endregion
        
        #region Parameter ContactPrePassDurationSecond
        /// <summary>
        /// <para>
        /// <para>Amount of time, in seconds, before a contact starts that the Ground Station Dataflow
        /// Endpoint Group will be in a <c>PREPASS</c> state. A Ground Station Dataflow Endpoint
        /// Group State Change event will be emitted when the Dataflow Endpoint Group enters and
        /// exits the <c>PREPASS</c> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContactPrePassDurationSeconds")]
        public System.Int32? ContactPrePassDurationSecond { get; set; }
        #endregion
        
        #region Parameter EndpointDetail
        /// <summary>
        /// <para>
        /// <para>Endpoint details of each endpoint in the dataflow endpoint group. All dataflow endpoints
        /// within a single dataflow endpoint group must be of the same type. You cannot mix <a href="https://docs.aws.amazon.com/ground-station/latest/APIReference/API_AwsGroundStationAgentEndpoint.html">
        /// AWS Ground Station Agent endpoints</a> with <a href="https://docs.aws.amazon.com/ground-station/latest/APIReference/API_DataflowEndpoint.html">Dataflow
        /// endpoints</a> in the same group. If your use case requires both types of endpoints,
        /// you must create separate dataflow endpoint groups for each type. </para>
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
        [Alias("EndpointDetails")]
        public Amazon.GroundStation.Model.EndpointDetails[] EndpointDetail { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags of a dataflow endpoint group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataflowEndpointGroupId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataflowEndpointGroupId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointDetail parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointDetail' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointDetail' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointDetail), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSDataflowEndpointGroup (CreateDataflowEndpointGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse, NewGSDataflowEndpointGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointDetail;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactPostPassDurationSecond = this.ContactPostPassDurationSecond;
            context.ContactPrePassDurationSecond = this.ContactPrePassDurationSecond;
            if (this.EndpointDetail != null)
            {
                context.EndpointDetail = new List<Amazon.GroundStation.Model.EndpointDetails>(this.EndpointDetail);
            }
            #if MODULAR
            if (this.EndpointDetail == null && ParameterWasBound(nameof(this.EndpointDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.GroundStation.Model.CreateDataflowEndpointGroupRequest();
            
            if (cmdletContext.ContactPostPassDurationSecond != null)
            {
                request.ContactPostPassDurationSeconds = cmdletContext.ContactPostPassDurationSecond.Value;
            }
            if (cmdletContext.ContactPrePassDurationSecond != null)
            {
                request.ContactPrePassDurationSeconds = cmdletContext.ContactPrePassDurationSecond.Value;
            }
            if (cmdletContext.EndpointDetail != null)
            {
                request.EndpointDetails = cmdletContext.EndpointDetail;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateDataflowEndpointGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateDataflowEndpointGroup");
            try
            {
                #if DESKTOP
                return client.CreateDataflowEndpointGroup(request);
                #elif CORECLR
                return client.CreateDataflowEndpointGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ContactPostPassDurationSecond { get; set; }
            public System.Int32? ContactPrePassDurationSecond { get; set; }
            public List<Amazon.GroundStation.Model.EndpointDetails> EndpointDetail { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateDataflowEndpointGroupResponse, NewGSDataflowEndpointGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataflowEndpointGroupId;
        }
        
    }
}
