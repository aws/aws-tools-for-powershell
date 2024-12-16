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
    /// Provides the information necessary to update a configured audience model. Updates
    /// that impact audience generation jobs take effect when a new job starts, but do not
    /// impact currently running jobs.
    /// </summary>
    [Cmdlet("Update", "CRMLConfiguredAudienceModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML UpdateConfiguredAudienceModel API operation.", Operation = new[] {"UpdateConfiguredAudienceModel"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCRMLConfiguredAudienceModelCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AudienceModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the new audience model that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AudienceModelArn { get; set; }
        #endregion
        
        #region Parameter AudienceSizeConfig_AudienceSizeBin
        /// <summary>
        /// <para>
        /// <para>An array of the different audience output sizes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AudienceSizeConfig_AudienceSizeBins")]
        public System.Int32[] AudienceSizeConfig_AudienceSizeBin { get; set; }
        #endregion
        
        #region Parameter AudienceSizeConfig_AudienceSizeType
        /// <summary>
        /// <para>
        /// <para>Whether the audience output sizes are defined as an absolute number or a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRoomsML.AudienceSizeType")]
        public Amazon.CleanRoomsML.AudienceSizeType AudienceSizeConfig_AudienceSizeType { get; set; }
        #endregion
        
        #region Parameter ConfiguredAudienceModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configured audience model that you want to update.</para>
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
        public System.String ConfiguredAudienceModelArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description of the configured audience model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MinMatchingSeedSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of users from the seed audience that must match with users in the
        /// training data of the audience model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinMatchingSeedSize { get; set; }
        #endregion
        
        #region Parameter OutputConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that can write the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_Destination_S3Destination_S3Uri")]
        public System.String S3Destination_S3Uri { get; set; }
        #endregion
        
        #region Parameter SharedAudienceMetric
        /// <summary>
        /// <para>
        /// <para>The new value for whether to share audience metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SharedAudienceMetrics")]
        public System.String[] SharedAudienceMetric { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredAudienceModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredAudienceModelArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredAudienceModelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRMLConfiguredAudienceModel (UpdateConfiguredAudienceModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse, UpdateCRMLConfiguredAudienceModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AudienceModelArn = this.AudienceModelArn;
            if (this.AudienceSizeConfig_AudienceSizeBin != null)
            {
                context.AudienceSizeConfig_AudienceSizeBin = new List<System.Int32>(this.AudienceSizeConfig_AudienceSizeBin);
            }
            context.AudienceSizeConfig_AudienceSizeType = this.AudienceSizeConfig_AudienceSizeType;
            context.ConfiguredAudienceModelArn = this.ConfiguredAudienceModelArn;
            #if MODULAR
            if (this.ConfiguredAudienceModelArn == null && ParameterWasBound(nameof(this.ConfiguredAudienceModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredAudienceModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.MinMatchingSeedSize = this.MinMatchingSeedSize;
            context.S3Destination_S3Uri = this.S3Destination_S3Uri;
            context.OutputConfig_RoleArn = this.OutputConfig_RoleArn;
            if (this.SharedAudienceMetric != null)
            {
                context.SharedAudienceMetric = new List<System.String>(this.SharedAudienceMetric);
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
            var request = new Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelRequest();
            
            if (cmdletContext.AudienceModelArn != null)
            {
                request.AudienceModelArn = cmdletContext.AudienceModelArn;
            }
            
             // populate AudienceSizeConfig
            var requestAudienceSizeConfigIsNull = true;
            request.AudienceSizeConfig = new Amazon.CleanRoomsML.Model.AudienceSizeConfig();
            List<System.Int32> requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin = null;
            if (cmdletContext.AudienceSizeConfig_AudienceSizeBin != null)
            {
                requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin = cmdletContext.AudienceSizeConfig_AudienceSizeBin;
            }
            if (requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin != null)
            {
                request.AudienceSizeConfig.AudienceSizeBins = requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeBin;
                requestAudienceSizeConfigIsNull = false;
            }
            Amazon.CleanRoomsML.AudienceSizeType requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType = null;
            if (cmdletContext.AudienceSizeConfig_AudienceSizeType != null)
            {
                requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType = cmdletContext.AudienceSizeConfig_AudienceSizeType;
            }
            if (requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType != null)
            {
                request.AudienceSizeConfig.AudienceSizeType = requestAudienceSizeConfig_audienceSizeConfig_AudienceSizeType;
                requestAudienceSizeConfigIsNull = false;
            }
             // determine if request.AudienceSizeConfig should be set to null
            if (requestAudienceSizeConfigIsNull)
            {
                request.AudienceSizeConfig = null;
            }
            if (cmdletContext.ConfiguredAudienceModelArn != null)
            {
                request.ConfiguredAudienceModelArn = cmdletContext.ConfiguredAudienceModelArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MinMatchingSeedSize != null)
            {
                request.MinMatchingSeedSize = cmdletContext.MinMatchingSeedSize.Value;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.CleanRoomsML.Model.ConfiguredAudienceModelOutputConfig();
            System.String requestOutputConfig_outputConfig_RoleArn = null;
            if (cmdletContext.OutputConfig_RoleArn != null)
            {
                requestOutputConfig_outputConfig_RoleArn = cmdletContext.OutputConfig_RoleArn;
            }
            if (requestOutputConfig_outputConfig_RoleArn != null)
            {
                request.OutputConfig.RoleArn = requestOutputConfig_outputConfig_RoleArn;
                requestOutputConfigIsNull = false;
            }
            Amazon.CleanRoomsML.Model.AudienceDestination requestOutputConfig_outputConfig_Destination = null;
            
             // populate Destination
            var requestOutputConfig_outputConfig_DestinationIsNull = true;
            requestOutputConfig_outputConfig_Destination = new Amazon.CleanRoomsML.Model.AudienceDestination();
            Amazon.CleanRoomsML.Model.S3ConfigMap requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = null;
            
             // populate S3Destination
            var requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull = true;
            requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = new Amazon.CleanRoomsML.Model.S3ConfigMap();
            System.String requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri = null;
            if (cmdletContext.S3Destination_S3Uri != null)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri = cmdletContext.S3Destination_S3Uri;
            }
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri != null)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination.S3Uri = requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination_s3Destination_S3Uri;
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination should be set to null
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3DestinationIsNull)
            {
                requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination = null;
            }
            if (requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination != null)
            {
                requestOutputConfig_outputConfig_Destination.S3Destination = requestOutputConfig_outputConfig_Destination_outputConfig_Destination_S3Destination;
                requestOutputConfig_outputConfig_DestinationIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_Destination should be set to null
            if (requestOutputConfig_outputConfig_DestinationIsNull)
            {
                requestOutputConfig_outputConfig_Destination = null;
            }
            if (requestOutputConfig_outputConfig_Destination != null)
            {
                request.OutputConfig.Destination = requestOutputConfig_outputConfig_Destination;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.SharedAudienceMetric != null)
            {
                request.SharedAudienceMetrics = cmdletContext.SharedAudienceMetric;
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
        
        private Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "UpdateConfiguredAudienceModel");
            try
            {
                #if DESKTOP
                return client.UpdateConfiguredAudienceModel(request);
                #elif CORECLR
                return client.UpdateConfiguredAudienceModelAsync(request).GetAwaiter().GetResult();
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
            public System.String AudienceModelArn { get; set; }
            public List<System.Int32> AudienceSizeConfig_AudienceSizeBin { get; set; }
            public Amazon.CleanRoomsML.AudienceSizeType AudienceSizeConfig_AudienceSizeType { get; set; }
            public System.String ConfiguredAudienceModelArn { get; set; }
            public System.String Description { get; set; }
            public System.Int32? MinMatchingSeedSize { get; set; }
            public System.String S3Destination_S3Uri { get; set; }
            public System.String OutputConfig_RoleArn { get; set; }
            public List<System.String> SharedAudienceMetric { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.UpdateConfiguredAudienceModelResponse, UpdateCRMLConfiguredAudienceModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredAudienceModelArn;
        }
        
    }
}
