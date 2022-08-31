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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// <b>Greengrass and Cloud Deployments</b><para>
    /// Deploys the system instance to the target specified in <code>CreateSystemInstance</code>.
    /// 
    /// </para><para><b>Greengrass Deployments</b></para><para>
    /// If the system or any workflows and entities have been updated before this action is
    /// called, then the deployment will create a new Amazon Simple Storage Service resource
    /// file and then deploy it.
    /// </para><para>
    /// Since this action creates a Greengrass deployment on the caller's behalf, the calling
    /// identity must have write permissions to the specified Greengrass group. Otherwise,
    /// the call will fail with an authorization error.
    /// </para><para>
    /// For information about the artifacts that get added to your Greengrass core device
    /// when you use this API, see <a href="https://docs.aws.amazon.com/thingsgraph/latest/ug/iot-tg-greengrass.html">AWS
    /// IoT Things Graph and AWS IoT Greengrass</a>.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Add", "IOTTGSystemInstanceDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse")]
    [AWSCmdlet("Calls the AWS IoT Things Graph DeploySystemInstance API operation.", Operation = new[] {"DeploySystemInstance"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse",
        "This cmdlet returns an Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class AddIOTTGSystemInstanceDeploymentCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the system instance. This value is returned by the <code>CreateSystemInstance</code>
        /// action.</para><para>The ID should be in the following format.</para><para><code>urn:tdm:REGION/ACCOUNT ID/default:deployment:DEPLOYMENTNAME</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-IOTTGSystemInstanceDeployment (DeploySystemInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse, AddIOTTGSystemInstanceDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            
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
            var request = new Amazon.IoTThingsGraph.Model.DeploySystemInstanceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.DeploySystemInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "DeploySystemInstance");
            try
            {
                #if DESKTOP
                return client.DeploySystemInstance(request);
                #elif CORECLR
                return client.DeploySystemInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.DeploySystemInstanceResponse, AddIOTTGSystemInstanceDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
