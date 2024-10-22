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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Associates a list of client devices with a core device. Use this API operation to
    /// specify which client devices can discover a core device through cloud discovery. With
    /// cloud discovery, client devices connect to IoT Greengrass to retrieve associated core
    /// devices' connectivity information and certificates. For more information, see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/configure-cloud-discovery.html">Configure
    /// cloud discovery</a> in the <i>IoT Greengrass V2 Developer Guide</i>.
    /// 
    ///  <note><para>
    /// Client devices are local IoT devices that connect to and communicate with an IoT Greengrass
    /// core device over MQTT. You can connect client devices to a core device to sync MQTT
    /// messages and data to Amazon Web Services IoT Core and interact with client devices
    /// in Greengrass components. For more information, see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/interact-with-local-iot-devices.html">Interact
    /// with local IoT devices</a> in the <i>IoT Greengrass V2 Developer Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "GGV2BatchClientDeviceWithCoreDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceErrorEntry")]
    [AWSCmdlet("Calls the AWS GreengrassV2 BatchAssociateClientDeviceWithCoreDevice API operation.", Operation = new[] {"BatchAssociateClientDeviceWithCoreDevice"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceErrorEntry or Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceErrorEntry objects.",
        "The service call response (type Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddGGV2BatchClientDeviceWithCoreDeviceCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CoreDeviceThingName
        /// <summary>
        /// <para>
        /// <para>The name of the core device. This is also the name of the IoT thing.</para>
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
        public System.String CoreDeviceThingName { get; set; }
        #endregion
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>The list of client devices to associate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Entries")]
        public Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ErrorEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ErrorEntries";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CoreDeviceThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-GGV2BatchClientDeviceWithCoreDevice (BatchAssociateClientDeviceWithCoreDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse, AddGGV2BatchClientDeviceWithCoreDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CoreDeviceThingName = this.CoreDeviceThingName;
            #if MODULAR
            if (this.CoreDeviceThingName == null && ParameterWasBound(nameof(this.CoreDeviceThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreDeviceThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceEntry>(this.Entry);
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
            var request = new Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceRequest();
            
            if (cmdletContext.CoreDeviceThingName != null)
            {
                request.CoreDeviceThingName = cmdletContext.CoreDeviceThingName;
            }
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
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
        
        private Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "BatchAssociateClientDeviceWithCoreDevice");
            try
            {
                #if DESKTOP
                return client.BatchAssociateClientDeviceWithCoreDevice(request);
                #elif CORECLR
                return client.BatchAssociateClientDeviceWithCoreDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String CoreDeviceThingName { get; set; }
            public List<Amazon.GreengrassV2.Model.AssociateClientDeviceWithCoreDeviceEntry> Entry { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.BatchAssociateClientDeviceWithCoreDeviceResponse, AddGGV2BatchClientDeviceWithCoreDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ErrorEntries;
        }
        
    }
}
