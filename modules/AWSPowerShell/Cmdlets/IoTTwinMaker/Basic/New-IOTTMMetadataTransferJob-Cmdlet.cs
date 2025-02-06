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
using Amazon.IoTTwinMaker;
using Amazon.IoTTwinMaker.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTM
{
    /// <summary>
    /// Creates a new metadata transfer job.
    /// </summary>
    [Cmdlet("New", "IOTTMMetadataTransferJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker CreateMetadataTransferJob API operation.", Operation = new[] {"CreateMetadataTransferJob"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse",
        "This cmdlet returns an Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse object containing multiple properties."
    )]
    public partial class NewIOTTMMetadataTransferJobCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The metadata transfer job description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3Configuration_Location
        /// <summary>
        /// <para>
        /// <para>The S3 destination configuration location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_S3Configuration_Location")]
        public System.String S3Configuration_Location { get; set; }
        #endregion
        
        #region Parameter MetadataTransferJobId
        /// <summary>
        /// <para>
        /// <para>The metadata transfer job Id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataTransferJobId { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The metadata transfer job sources.</para>
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
        [Alias("Sources")]
        public Amazon.IoTTwinMaker.Model.SourceConfiguration[] Source { get; set; }
        #endregion
        
        #region Parameter Destination_Type
        /// <summary>
        /// <para>
        /// <para>The destination type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTTwinMaker.DestinationType")]
        public Amazon.IoTTwinMaker.DestinationType Destination_Type { get; set; }
        #endregion
        
        #region Parameter IotTwinMakerConfiguration_Workspace
        /// <summary>
        /// <para>
        /// <para>The IoT TwinMaker workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_IotTwinMakerConfiguration_Workspace")]
        public System.String IotTwinMakerConfiguration_Workspace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetadataTransferJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTMMetadataTransferJob (CreateMetadataTransferJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse, NewIOTTMMetadataTransferJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.IotTwinMakerConfiguration_Workspace = this.IotTwinMakerConfiguration_Workspace;
            context.S3Configuration_Location = this.S3Configuration_Location;
            context.Destination_Type = this.Destination_Type;
            #if MODULAR
            if (this.Destination_Type == null && ParameterWasBound(nameof(this.Destination_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataTransferJobId = this.MetadataTransferJobId;
            if (this.Source != null)
            {
                context.Source = new List<Amazon.IoTTwinMaker.Model.SourceConfiguration>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.IoTTwinMaker.Model.DestinationConfiguration();
            Amazon.IoTTwinMaker.DestinationType requestDestination_destination_Type = null;
            if (cmdletContext.Destination_Type != null)
            {
                requestDestination_destination_Type = cmdletContext.Destination_Type;
            }
            if (requestDestination_destination_Type != null)
            {
                request.Destination.Type = requestDestination_destination_Type;
                requestDestinationIsNull = false;
            }
            Amazon.IoTTwinMaker.Model.IotTwinMakerDestinationConfiguration requestDestination_destination_IotTwinMakerConfiguration = null;
            
             // populate IotTwinMakerConfiguration
            var requestDestination_destination_IotTwinMakerConfigurationIsNull = true;
            requestDestination_destination_IotTwinMakerConfiguration = new Amazon.IoTTwinMaker.Model.IotTwinMakerDestinationConfiguration();
            System.String requestDestination_destination_IotTwinMakerConfiguration_iotTwinMakerConfiguration_Workspace = null;
            if (cmdletContext.IotTwinMakerConfiguration_Workspace != null)
            {
                requestDestination_destination_IotTwinMakerConfiguration_iotTwinMakerConfiguration_Workspace = cmdletContext.IotTwinMakerConfiguration_Workspace;
            }
            if (requestDestination_destination_IotTwinMakerConfiguration_iotTwinMakerConfiguration_Workspace != null)
            {
                requestDestination_destination_IotTwinMakerConfiguration.Workspace = requestDestination_destination_IotTwinMakerConfiguration_iotTwinMakerConfiguration_Workspace;
                requestDestination_destination_IotTwinMakerConfigurationIsNull = false;
            }
             // determine if requestDestination_destination_IotTwinMakerConfiguration should be set to null
            if (requestDestination_destination_IotTwinMakerConfigurationIsNull)
            {
                requestDestination_destination_IotTwinMakerConfiguration = null;
            }
            if (requestDestination_destination_IotTwinMakerConfiguration != null)
            {
                request.Destination.IotTwinMakerConfiguration = requestDestination_destination_IotTwinMakerConfiguration;
                requestDestinationIsNull = false;
            }
            Amazon.IoTTwinMaker.Model.S3DestinationConfiguration requestDestination_destination_S3Configuration = null;
            
             // populate S3Configuration
            var requestDestination_destination_S3ConfigurationIsNull = true;
            requestDestination_destination_S3Configuration = new Amazon.IoTTwinMaker.Model.S3DestinationConfiguration();
            System.String requestDestination_destination_S3Configuration_s3Configuration_Location = null;
            if (cmdletContext.S3Configuration_Location != null)
            {
                requestDestination_destination_S3Configuration_s3Configuration_Location = cmdletContext.S3Configuration_Location;
            }
            if (requestDestination_destination_S3Configuration_s3Configuration_Location != null)
            {
                requestDestination_destination_S3Configuration.Location = requestDestination_destination_S3Configuration_s3Configuration_Location;
                requestDestination_destination_S3ConfigurationIsNull = false;
            }
             // determine if requestDestination_destination_S3Configuration should be set to null
            if (requestDestination_destination_S3ConfigurationIsNull)
            {
                requestDestination_destination_S3Configuration = null;
            }
            if (requestDestination_destination_S3Configuration != null)
            {
                request.Destination.S3Configuration = requestDestination_destination_S3Configuration;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.MetadataTransferJobId != null)
            {
                request.MetadataTransferJobId = cmdletContext.MetadataTransferJobId;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
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
        
        private Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "CreateMetadataTransferJob");
            try
            {
                #if DESKTOP
                return client.CreateMetadataTransferJob(request);
                #elif CORECLR
                return client.CreateMetadataTransferJobAsync(request).GetAwaiter().GetResult();
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
            public System.String IotTwinMakerConfiguration_Workspace { get; set; }
            public System.String S3Configuration_Location { get; set; }
            public Amazon.IoTTwinMaker.DestinationType Destination_Type { get; set; }
            public System.String MetadataTransferJobId { get; set; }
            public List<Amazon.IoTTwinMaker.Model.SourceConfiguration> Source { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.CreateMetadataTransferJobResponse, NewIOTTMMetadataTransferJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
