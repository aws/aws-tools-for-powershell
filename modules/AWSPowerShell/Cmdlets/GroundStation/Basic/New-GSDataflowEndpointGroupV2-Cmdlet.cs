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
    /// Creates a <c>DataflowEndpointGroupV2</c> containing the specified list of <c>DataflowEndpoint</c>
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
    [Cmdlet("New", "GSDataflowEndpointGroupV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station CreateDataflowEndpointGroupV2 API operation.", Operation = new[] {"CreateDataflowEndpointGroupV2"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class NewGSDataflowEndpointGroupV2Cmdlet : AmazonGroundStationClientCmdlet, IExecutor
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
        
        #region Parameter Endpoint
        /// <summary>
        /// <para>
        /// <para>Dataflow endpoint group's endpoint definitions</para>
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
        [Alias("Endpoints")]
        public Amazon.GroundStation.Model.CreateEndpointDetails[] Endpoint { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags of a V2 dataflow endpoint group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataflowEndpointGroupId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataflowEndpointGroupId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSDataflowEndpointGroupV2 (CreateDataflowEndpointGroupV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response, NewGSDataflowEndpointGroupV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactPostPassDurationSecond = this.ContactPostPassDurationSecond;
            context.ContactPrePassDurationSecond = this.ContactPrePassDurationSecond;
            if (this.Endpoint != null)
            {
                context.Endpoint = new List<Amazon.GroundStation.Model.CreateEndpointDetails>(this.Endpoint);
            }
            #if MODULAR
            if (this.Endpoint == null && ParameterWasBound(nameof(this.Endpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter Endpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Request();
            
            if (cmdletContext.ContactPostPassDurationSecond != null)
            {
                request.ContactPostPassDurationSeconds = cmdletContext.ContactPostPassDurationSecond.Value;
            }
            if (cmdletContext.ContactPrePassDurationSecond != null)
            {
                request.ContactPrePassDurationSeconds = cmdletContext.ContactPrePassDurationSecond.Value;
            }
            if (cmdletContext.Endpoint != null)
            {
                request.Endpoints = cmdletContext.Endpoint;
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
        
        private Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateDataflowEndpointGroupV2");
            try
            {
                #if DESKTOP
                return client.CreateDataflowEndpointGroupV2(request);
                #elif CORECLR
                return client.CreateDataflowEndpointGroupV2Async(request).GetAwaiter().GetResult();
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
            public List<Amazon.GroundStation.Model.CreateEndpointDetails> Endpoint { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateDataflowEndpointGroupV2Response, NewGSDataflowEndpointGroupV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataflowEndpointGroupId;
        }
        
    }
}
