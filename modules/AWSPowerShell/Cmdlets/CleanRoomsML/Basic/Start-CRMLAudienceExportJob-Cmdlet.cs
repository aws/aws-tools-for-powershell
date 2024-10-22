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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Export an audience of a specified size after you have generated an audience.
    /// </summary>
    [Cmdlet("Start", "CRMLAudienceExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CleanRoomsML StartAudienceExportJob API operation.", Operation = new[] {"StartAudienceExportJob"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse))]
    [AWSCmdletOutput("None or Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCRMLAudienceExportJobCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AudienceGenerationJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the audience generation job that you want to export.</para>
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
        public System.String AudienceGenerationJobArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the audience export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the audience export job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AudienceSize_Type
        /// <summary>
        /// <para>
        /// <para>Whether the audience size is defined in absolute terms or as a percentage. You can
        /// use the <c>ABSOLUTE</c><a>AudienceSize</a> to configure out audience sizes using
        /// the count of identifiers in the output. You can use the <c>Percentage</c><a>AudienceSize</a>
        /// to configure sizes in the range 1-100 percent.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRoomsML.AudienceSizeType")]
        public Amazon.CleanRoomsML.AudienceSizeType AudienceSize_Type { get; set; }
        #endregion
        
        #region Parameter AudienceSize_Value
        /// <summary>
        /// <para>
        /// <para>Specify an audience size value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? AudienceSize_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRMLAudienceExportJob (StartAudienceExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse, StartCRMLAudienceExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AudienceGenerationJobArn = this.AudienceGenerationJobArn;
            #if MODULAR
            if (this.AudienceGenerationJobArn == null && ParameterWasBound(nameof(this.AudienceGenerationJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AudienceGenerationJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AudienceSize_Type = this.AudienceSize_Type;
            #if MODULAR
            if (this.AudienceSize_Type == null && ParameterWasBound(nameof(this.AudienceSize_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter AudienceSize_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AudienceSize_Value = this.AudienceSize_Value;
            #if MODULAR
            if (this.AudienceSize_Value == null && ParameterWasBound(nameof(this.AudienceSize_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter AudienceSize_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRoomsML.Model.StartAudienceExportJobRequest();
            
            if (cmdletContext.AudienceGenerationJobArn != null)
            {
                request.AudienceGenerationJobArn = cmdletContext.AudienceGenerationJobArn;
            }
            
             // populate AudienceSize
            var requestAudienceSizeIsNull = true;
            request.AudienceSize = new Amazon.CleanRoomsML.Model.AudienceSize();
            Amazon.CleanRoomsML.AudienceSizeType requestAudienceSize_audienceSize_Type = null;
            if (cmdletContext.AudienceSize_Type != null)
            {
                requestAudienceSize_audienceSize_Type = cmdletContext.AudienceSize_Type;
            }
            if (requestAudienceSize_audienceSize_Type != null)
            {
                request.AudienceSize.Type = requestAudienceSize_audienceSize_Type;
                requestAudienceSizeIsNull = false;
            }
            System.Int32? requestAudienceSize_audienceSize_Value = null;
            if (cmdletContext.AudienceSize_Value != null)
            {
                requestAudienceSize_audienceSize_Value = cmdletContext.AudienceSize_Value.Value;
            }
            if (requestAudienceSize_audienceSize_Value != null)
            {
                request.AudienceSize.Value = requestAudienceSize_audienceSize_Value.Value;
                requestAudienceSizeIsNull = false;
            }
             // determine if request.AudienceSize should be set to null
            if (requestAudienceSizeIsNull)
            {
                request.AudienceSize = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.StartAudienceExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "StartAudienceExportJob");
            try
            {
                #if DESKTOP
                return client.StartAudienceExportJob(request);
                #elif CORECLR
                return client.StartAudienceExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String AudienceGenerationJobArn { get; set; }
            public Amazon.CleanRoomsML.AudienceSizeType AudienceSize_Type { get; set; }
            public System.Int32? AudienceSize_Value { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.StartAudienceExportJobResponse, StartCRMLAudienceExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
