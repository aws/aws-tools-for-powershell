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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Start import task for provisioning Sidewalk devices in bulk using an S3 CSV file.
    /// </summary>
    [Cmdlet("Start", "IOTWWirelessDeviceImportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless StartWirelessDeviceImportTask API operation.", Operation = new[] {"StartWirelessDeviceImportTask"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse object containing multiple properties."
    )]
    public partial class StartIOTWWirelessDeviceImportTaskCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>The name of the Sidewalk destination that describes the IoT rule to route messages
        /// from the devices in the import task that are onboarded to AWS IoT Wireless.</para>
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
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter Sidewalk_DeviceCreationFile
        /// <summary>
        /// <para>
        /// <para>The CSV file contained in an S3 bucket that's used for adding devices to an import
        /// task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_DeviceCreationFile { get; set; }
        #endregion
        
        #region Parameter Sidewalk_Role
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows AWS IoT Wireless to access the CSV file in the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_Role { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTWWirelessDeviceImportTask (StartWirelessDeviceImportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse, StartIOTWWirelessDeviceImportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.DestinationName = this.DestinationName;
            #if MODULAR
            if (this.DestinationName == null && ParameterWasBound(nameof(this.DestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sidewalk_DeviceCreationFile = this.Sidewalk_DeviceCreationFile;
            context.Sidewalk_Role = this.Sidewalk_Role;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            
             // populate Sidewalk
            var requestSidewalkIsNull = true;
            request.Sidewalk = new Amazon.IoTWireless.Model.SidewalkStartImportInfo();
            System.String requestSidewalk_sidewalk_DeviceCreationFile = null;
            if (cmdletContext.Sidewalk_DeviceCreationFile != null)
            {
                requestSidewalk_sidewalk_DeviceCreationFile = cmdletContext.Sidewalk_DeviceCreationFile;
            }
            if (requestSidewalk_sidewalk_DeviceCreationFile != null)
            {
                request.Sidewalk.DeviceCreationFile = requestSidewalk_sidewalk_DeviceCreationFile;
                requestSidewalkIsNull = false;
            }
            System.String requestSidewalk_sidewalk_Role = null;
            if (cmdletContext.Sidewalk_Role != null)
            {
                requestSidewalk_sidewalk_Role = cmdletContext.Sidewalk_Role;
            }
            if (requestSidewalk_sidewalk_Role != null)
            {
                request.Sidewalk.Role = requestSidewalk_sidewalk_Role;
                requestSidewalkIsNull = false;
            }
             // determine if request.Sidewalk should be set to null
            if (requestSidewalkIsNull)
            {
                request.Sidewalk = null;
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
        
        private Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "StartWirelessDeviceImportTask");
            try
            {
                #if DESKTOP
                return client.StartWirelessDeviceImportTask(request);
                #elif CORECLR
                return client.StartWirelessDeviceImportTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DestinationName { get; set; }
            public System.String Sidewalk_DeviceCreationFile { get; set; }
            public System.String Sidewalk_Role { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.StartWirelessDeviceImportTaskResponse, StartIOTWWirelessDeviceImportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
