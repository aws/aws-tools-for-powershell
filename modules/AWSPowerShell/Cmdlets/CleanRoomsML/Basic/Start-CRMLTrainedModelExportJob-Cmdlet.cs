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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Provides the information necessary to start a trained model export job.
    /// </summary>
    [Cmdlet("Start", "CRMLTrainedModelExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CleanRoomsML StartTrainedModelExportJob API operation.", Operation = new[] {"StartTrainedModelExportJob"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse))]
    [AWSCmdletOutput("None or Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartCRMLTrainedModelExportJobCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the trained model export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_Member
        /// <summary>
        /// <para>
        /// <para>The members that will received the exported trained model output.</para>
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
        [Alias("OutputConfiguration_Members")]
        public Amazon.CleanRoomsML.Model.TrainedModelExportReceiverMember[] OutputConfiguration_Member { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the member that is receiving the exported trained model artifacts.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the trained model export job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TrainedModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trained model that you want to export.</para>
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
        public System.String TrainedModelArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRMLTrainedModelExportJob (StartTrainedModelExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse, StartCRMLTrainedModelExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputConfiguration_Member != null)
            {
                context.OutputConfiguration_Member = new List<Amazon.CleanRoomsML.Model.TrainedModelExportReceiverMember>(this.OutputConfiguration_Member);
            }
            #if MODULAR
            if (this.OutputConfiguration_Member == null && ParameterWasBound(nameof(this.OutputConfiguration_Member)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_Member which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainedModelArn = this.TrainedModelArn;
            #if MODULAR
            if (this.TrainedModelArn == null && ParameterWasBound(nameof(this.TrainedModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainedModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.CleanRoomsML.Model.StartTrainedModelExportJobRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.CleanRoomsML.Model.TrainedModelExportOutputConfiguration();
            List<Amazon.CleanRoomsML.Model.TrainedModelExportReceiverMember> requestOutputConfiguration_outputConfiguration_Member = null;
            if (cmdletContext.OutputConfiguration_Member != null)
            {
                requestOutputConfiguration_outputConfiguration_Member = cmdletContext.OutputConfiguration_Member;
            }
            if (requestOutputConfiguration_outputConfiguration_Member != null)
            {
                request.OutputConfiguration.Members = requestOutputConfiguration_outputConfiguration_Member;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            if (cmdletContext.TrainedModelArn != null)
            {
                request.TrainedModelArn = cmdletContext.TrainedModelArn;
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
        
        private Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.StartTrainedModelExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "StartTrainedModelExportJob");
            try
            {
                #if DESKTOP
                return client.StartTrainedModelExportJob(request);
                #elif CORECLR
                return client.StartTrainedModelExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CleanRoomsML.Model.TrainedModelExportReceiverMember> OutputConfiguration_Member { get; set; }
            public System.String TrainedModelArn { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.StartTrainedModelExportJobResponse, StartCRMLTrainedModelExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
