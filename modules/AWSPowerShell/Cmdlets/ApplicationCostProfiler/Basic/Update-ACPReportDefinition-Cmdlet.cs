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
using Amazon.ApplicationCostProfiler;
using Amazon.ApplicationCostProfiler.Model;

namespace Amazon.PowerShell.Cmdlets.ACP
{
    /// <summary>
    /// Updates existing report in AWS Application Cost Profiler.
    /// </summary>
    [Cmdlet("Update", "ACPReportDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon ApplicationCostProfiler UpdateReportDefinition API operation.", Operation = new[] {"UpdateReportDefinition"}, SelectReturnType = typeof(Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateACPReportDefinitionCmdlet : AmazonApplicationCostProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
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
        public System.String DestinationS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>Required. The format to use for the generated report.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationCostProfiler.Format")]
        public Amazon.ApplicationCostProfiler.Format Format { get; set; }
        #endregion
        
        #region Parameter DestinationS3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>Prefix for the location to write to.</para>
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
        public System.String DestinationS3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter ReportDescription
        /// <summary>
        /// <para>
        /// <para>Required. Description of the report.</para>
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
        public System.String ReportDescription { get; set; }
        #endregion
        
        #region Parameter ReportFrequency
        /// <summary>
        /// <para>
        /// <para>Required. The cadence to generate the report.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationCostProfiler.ReportFrequency")]
        public Amazon.ApplicationCostProfiler.ReportFrequency ReportFrequency { get; set; }
        #endregion
        
        #region Parameter ReportId
        /// <summary>
        /// <para>
        /// <para>Required. ID of the report to update.</para>
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
        public System.String ReportId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse).
        /// Specifying the name of a property of type Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReportId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReportId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReportId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReportId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReportId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ACPReportDefinition (UpdateReportDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse, UpdateACPReportDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReportId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationS3Location_Bucket = this.DestinationS3Location_Bucket;
            #if MODULAR
            if (this.DestinationS3Location_Bucket == null && ParameterWasBound(nameof(this.DestinationS3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationS3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationS3Location_Prefix = this.DestinationS3Location_Prefix;
            #if MODULAR
            if (this.DestinationS3Location_Prefix == null && ParameterWasBound(nameof(this.DestinationS3Location_Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationS3Location_Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDescription = this.ReportDescription;
            #if MODULAR
            if (this.ReportDescription == null && ParameterWasBound(nameof(this.ReportDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportFrequency = this.ReportFrequency;
            #if MODULAR
            if (this.ReportFrequency == null && ParameterWasBound(nameof(this.ReportFrequency)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportFrequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportId = this.ReportId;
            #if MODULAR
            if (this.ReportId == null && ParameterWasBound(nameof(this.ReportId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionRequest();
            
            
             // populate DestinationS3Location
            var requestDestinationS3LocationIsNull = true;
            request.DestinationS3Location = new Amazon.ApplicationCostProfiler.Model.S3Location();
            System.String requestDestinationS3Location_destinationS3Location_Bucket = null;
            if (cmdletContext.DestinationS3Location_Bucket != null)
            {
                requestDestinationS3Location_destinationS3Location_Bucket = cmdletContext.DestinationS3Location_Bucket;
            }
            if (requestDestinationS3Location_destinationS3Location_Bucket != null)
            {
                request.DestinationS3Location.Bucket = requestDestinationS3Location_destinationS3Location_Bucket;
                requestDestinationS3LocationIsNull = false;
            }
            System.String requestDestinationS3Location_destinationS3Location_Prefix = null;
            if (cmdletContext.DestinationS3Location_Prefix != null)
            {
                requestDestinationS3Location_destinationS3Location_Prefix = cmdletContext.DestinationS3Location_Prefix;
            }
            if (requestDestinationS3Location_destinationS3Location_Prefix != null)
            {
                request.DestinationS3Location.Prefix = requestDestinationS3Location_destinationS3Location_Prefix;
                requestDestinationS3LocationIsNull = false;
            }
             // determine if request.DestinationS3Location should be set to null
            if (requestDestinationS3LocationIsNull)
            {
                request.DestinationS3Location = null;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.ReportDescription != null)
            {
                request.ReportDescription = cmdletContext.ReportDescription;
            }
            if (cmdletContext.ReportFrequency != null)
            {
                request.ReportFrequency = cmdletContext.ReportFrequency;
            }
            if (cmdletContext.ReportId != null)
            {
                request.ReportId = cmdletContext.ReportId;
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
        
        private Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse CallAWSServiceOperation(IAmazonApplicationCostProfiler client, Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ApplicationCostProfiler", "UpdateReportDefinition");
            try
            {
                #if DESKTOP
                return client.UpdateReportDefinition(request);
                #elif CORECLR
                return client.UpdateReportDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationS3Location_Bucket { get; set; }
            public System.String DestinationS3Location_Prefix { get; set; }
            public Amazon.ApplicationCostProfiler.Format Format { get; set; }
            public System.String ReportDescription { get; set; }
            public Amazon.ApplicationCostProfiler.ReportFrequency ReportFrequency { get; set; }
            public System.String ReportId { get; set; }
            public System.Func<Amazon.ApplicationCostProfiler.Model.UpdateReportDefinitionResponse, UpdateACPReportDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReportId;
        }
        
    }
}
