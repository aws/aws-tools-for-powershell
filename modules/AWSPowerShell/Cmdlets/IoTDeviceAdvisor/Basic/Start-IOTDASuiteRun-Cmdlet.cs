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
using Amazon.IoTDeviceAdvisor;
using Amazon.IoTDeviceAdvisor.Model;

namespace Amazon.PowerShell.Cmdlets.IOTDA
{
    /// <summary>
    /// Starts a Device Advisor test suite run.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">StartSuiteRun</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "IOTDASuiteRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse")]
    [AWSCmdlet("Calls the AWS IoT Core Device Advisor StartSuiteRun API operation.", Operation = new[] {"StartSuiteRun"}, SelectReturnType = typeof(Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse))]
    [AWSCmdletOutput("Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse",
        "This cmdlet returns an Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse object containing multiple properties."
    )]
    public partial class StartIOTDASuiteRunCmdlet : AmazonIoTDeviceAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PrimaryDevice_CertificateArn
        /// <summary>
        /// <para>
        /// <para>Lists device's certificate ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuiteRunConfiguration_PrimaryDevice_CertificateArn")]
        public System.String PrimaryDevice_CertificateArn { get; set; }
        #endregion
        
        #region Parameter PrimaryDevice_DeviceRoleArn
        /// <summary>
        /// <para>
        /// <para>Lists device's role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuiteRunConfiguration_PrimaryDevice_DeviceRoleArn")]
        public System.String PrimaryDevice_DeviceRoleArn { get; set; }
        #endregion
        
        #region Parameter SuiteRunConfiguration_ParallelRun
        /// <summary>
        /// <para>
        /// <para>TRUE if multiple test suites run in parallel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SuiteRunConfiguration_ParallelRun { get; set; }
        #endregion
        
        #region Parameter SuiteRunConfiguration_SelectedTestList
        /// <summary>
        /// <para>
        /// <para>Sets test case list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SuiteRunConfiguration_SelectedTestList { get; set; }
        #endregion
        
        #region Parameter SuiteDefinitionId
        /// <summary>
        /// <para>
        /// <para>Suite definition ID of the test suite.</para>
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
        public System.String SuiteDefinitionId { get; set; }
        #endregion
        
        #region Parameter SuiteDefinitionVersion
        /// <summary>
        /// <para>
        /// <para>Suite definition version of the test suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SuiteDefinitionVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be attached to the suite run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PrimaryDevice_ThingArn
        /// <summary>
        /// <para>
        /// <para>Lists device's thing ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuiteRunConfiguration_PrimaryDevice_ThingArn")]
        public System.String PrimaryDevice_ThingArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse).
        /// Specifying the name of a property of type Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SuiteDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTDASuiteRun (StartSuiteRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse, StartIOTDASuiteRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SuiteDefinitionId = this.SuiteDefinitionId;
            #if MODULAR
            if (this.SuiteDefinitionId == null && ParameterWasBound(nameof(this.SuiteDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SuiteDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SuiteDefinitionVersion = this.SuiteDefinitionVersion;
            context.SuiteRunConfiguration_ParallelRun = this.SuiteRunConfiguration_ParallelRun;
            context.PrimaryDevice_CertificateArn = this.PrimaryDevice_CertificateArn;
            context.PrimaryDevice_DeviceRoleArn = this.PrimaryDevice_DeviceRoleArn;
            context.PrimaryDevice_ThingArn = this.PrimaryDevice_ThingArn;
            if (this.SuiteRunConfiguration_SelectedTestList != null)
            {
                context.SuiteRunConfiguration_SelectedTestList = new List<System.String>(this.SuiteRunConfiguration_SelectedTestList);
            }
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
            var request = new Amazon.IoTDeviceAdvisor.Model.StartSuiteRunRequest();
            
            if (cmdletContext.SuiteDefinitionId != null)
            {
                request.SuiteDefinitionId = cmdletContext.SuiteDefinitionId;
            }
            if (cmdletContext.SuiteDefinitionVersion != null)
            {
                request.SuiteDefinitionVersion = cmdletContext.SuiteDefinitionVersion;
            }
            
             // populate SuiteRunConfiguration
            var requestSuiteRunConfigurationIsNull = true;
            request.SuiteRunConfiguration = new Amazon.IoTDeviceAdvisor.Model.SuiteRunConfiguration();
            System.Boolean? requestSuiteRunConfiguration_suiteRunConfiguration_ParallelRun = null;
            if (cmdletContext.SuiteRunConfiguration_ParallelRun != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_ParallelRun = cmdletContext.SuiteRunConfiguration_ParallelRun.Value;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_ParallelRun != null)
            {
                request.SuiteRunConfiguration.ParallelRun = requestSuiteRunConfiguration_suiteRunConfiguration_ParallelRun.Value;
                requestSuiteRunConfigurationIsNull = false;
            }
            List<System.String> requestSuiteRunConfiguration_suiteRunConfiguration_SelectedTestList = null;
            if (cmdletContext.SuiteRunConfiguration_SelectedTestList != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_SelectedTestList = cmdletContext.SuiteRunConfiguration_SelectedTestList;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_SelectedTestList != null)
            {
                request.SuiteRunConfiguration.SelectedTestList = requestSuiteRunConfiguration_suiteRunConfiguration_SelectedTestList;
                requestSuiteRunConfigurationIsNull = false;
            }
            Amazon.IoTDeviceAdvisor.Model.DeviceUnderTest requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice = null;
            
             // populate PrimaryDevice
            var requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDeviceIsNull = true;
            requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice = new Amazon.IoTDeviceAdvisor.Model.DeviceUnderTest();
            System.String requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_CertificateArn = null;
            if (cmdletContext.PrimaryDevice_CertificateArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_CertificateArn = cmdletContext.PrimaryDevice_CertificateArn;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_CertificateArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice.CertificateArn = requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_CertificateArn;
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDeviceIsNull = false;
            }
            System.String requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_DeviceRoleArn = null;
            if (cmdletContext.PrimaryDevice_DeviceRoleArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_DeviceRoleArn = cmdletContext.PrimaryDevice_DeviceRoleArn;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_DeviceRoleArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice.DeviceRoleArn = requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_DeviceRoleArn;
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDeviceIsNull = false;
            }
            System.String requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_ThingArn = null;
            if (cmdletContext.PrimaryDevice_ThingArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_ThingArn = cmdletContext.PrimaryDevice_ThingArn;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_ThingArn != null)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice.ThingArn = requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice_primaryDevice_ThingArn;
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDeviceIsNull = false;
            }
             // determine if requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice should be set to null
            if (requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDeviceIsNull)
            {
                requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice = null;
            }
            if (requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice != null)
            {
                request.SuiteRunConfiguration.PrimaryDevice = requestSuiteRunConfiguration_suiteRunConfiguration_PrimaryDevice;
                requestSuiteRunConfigurationIsNull = false;
            }
             // determine if request.SuiteRunConfiguration should be set to null
            if (requestSuiteRunConfigurationIsNull)
            {
                request.SuiteRunConfiguration = null;
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
        
        private Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse CallAWSServiceOperation(IAmazonIoTDeviceAdvisor client, Amazon.IoTDeviceAdvisor.Model.StartSuiteRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Core Device Advisor", "StartSuiteRun");
            try
            {
                #if DESKTOP
                return client.StartSuiteRun(request);
                #elif CORECLR
                return client.StartSuiteRunAsync(request).GetAwaiter().GetResult();
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
            public System.String SuiteDefinitionId { get; set; }
            public System.String SuiteDefinitionVersion { get; set; }
            public System.Boolean? SuiteRunConfiguration_ParallelRun { get; set; }
            public System.String PrimaryDevice_CertificateArn { get; set; }
            public System.String PrimaryDevice_DeviceRoleArn { get; set; }
            public System.String PrimaryDevice_ThingArn { get; set; }
            public List<System.String> SuiteRunConfiguration_SelectedTestList { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTDeviceAdvisor.Model.StartSuiteRunResponse, StartIOTDASuiteRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
