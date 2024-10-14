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
    /// Disassociates a list of client devices from a core device. After you disassociate
    /// a client device from a core device, the client device won't be able to use cloud discovery
    /// to retrieve the core device's connectivity information and certificates.
    /// </summary>
    [Cmdlet("Remove", "GGV2BatchClientDeviceFromCoreDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceErrorEntry")]
    [AWSCmdlet("Calls the AWS GreengrassV2 BatchDisassociateClientDeviceFromCoreDevice API operation.", Operation = new[] {"BatchDisassociateClientDeviceFromCoreDevice"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceErrorEntry or Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceErrorEntry objects.",
        "The service call response (type Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveGGV2BatchClientDeviceFromCoreDeviceCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
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
        /// <para>The list of client devices to disassociate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Entries")]
        public Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ErrorEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ErrorEntries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CoreDeviceThingName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CoreDeviceThingName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CoreDeviceThingName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CoreDeviceThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GGV2BatchClientDeviceFromCoreDevice (BatchDisassociateClientDeviceFromCoreDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse, RemoveGGV2BatchClientDeviceFromCoreDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CoreDeviceThingName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CoreDeviceThingName = this.CoreDeviceThingName;
            #if MODULAR
            if (this.CoreDeviceThingName == null && ParameterWasBound(nameof(this.CoreDeviceThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreDeviceThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceEntry>(this.Entry);
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
            var request = new Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceRequest();
            
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
        
        private Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "BatchDisassociateClientDeviceFromCoreDevice");
            try
            {
                #if DESKTOP
                return client.BatchDisassociateClientDeviceFromCoreDevice(request);
                #elif CORECLR
                return client.BatchDisassociateClientDeviceFromCoreDeviceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GreengrassV2.Model.DisassociateClientDeviceFromCoreDeviceEntry> Entry { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.BatchDisassociateClientDeviceFromCoreDeviceResponse, RemoveGGV2BatchClientDeviceFromCoreDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ErrorEntries;
        }
        
    }
}
