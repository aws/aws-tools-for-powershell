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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Updates the maintenance configuration of the Managed Service for Apache Flink application.
    /// 
    /// 
    ///  
    /// <para>
    /// You can invoke this operation on an application that is in one of the two following
    /// states: <c>READY</c> or <c>RUNNING</c>. If you invoke it when the application is in
    /// a state other than these two states, it throws a <c>ResourceInUseException</c>. The
    /// service makes use of the updated configuration the next time it schedules maintenance
    /// for the application. If you invoke this operation after the service schedules maintenance,
    /// the service will apply the configuration update the next time it schedules maintenance
    /// for the application. This means that you might not see the maintenance configuration
    /// update applied to the maintenance process that follows a successful invocation of
    /// this operation, but to the following maintenance process instead.
    /// </para><para>
    /// To see the current maintenance configuration of your application, invoke the <a>DescribeApplication</a>
    /// operation.
    /// </para><para>
    /// For information about application maintenance, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/maintenance.html">Managed
    /// Service for Apache Flink for Apache Flink Maintenance</a>.
    /// </para><note><para>
    /// This operation is supported only for Managed Service for Apache Flink.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "KINA2ApplicationMaintenanceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 UpdateApplicationMaintenanceConfiguration API operation.", Operation = new[] {"UpdateApplicationMaintenanceConfiguration"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKINA2ApplicationMaintenanceConfigurationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate
        /// <summary>
        /// <para>
        /// <para>The updated start time for the maintenance window.</para>
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
        public System.String ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application for which you want to update the maintenance configuration.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINA2ApplicationMaintenanceConfiguration (UpdateApplicationMaintenanceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse, UpdateKINA2ApplicationMaintenanceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate = this.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate;
            #if MODULAR
            if (this.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate == null && ParameterWasBound(nameof(this.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationRequest();
            
            
             // populate ApplicationMaintenanceConfigurationUpdate
            var requestApplicationMaintenanceConfigurationUpdateIsNull = true;
            request.ApplicationMaintenanceConfigurationUpdate = new Amazon.KinesisAnalyticsV2.Model.ApplicationMaintenanceConfigurationUpdate();
            System.String requestApplicationMaintenanceConfigurationUpdate_applicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate = null;
            if (cmdletContext.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate != null)
            {
                requestApplicationMaintenanceConfigurationUpdate_applicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate = cmdletContext.ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate;
            }
            if (requestApplicationMaintenanceConfigurationUpdate_applicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate != null)
            {
                request.ApplicationMaintenanceConfigurationUpdate.ApplicationMaintenanceWindowStartTimeUpdate = requestApplicationMaintenanceConfigurationUpdate_applicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate;
                requestApplicationMaintenanceConfigurationUpdateIsNull = false;
            }
             // determine if request.ApplicationMaintenanceConfigurationUpdate should be set to null
            if (requestApplicationMaintenanceConfigurationUpdateIsNull)
            {
                request.ApplicationMaintenanceConfigurationUpdate = null;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
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
        
        private Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "UpdateApplicationMaintenanceConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationMaintenanceConfiguration(request);
                #elif CORECLR
                return client.UpdateApplicationMaintenanceConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationMaintenanceConfigurationUpdate_ApplicationMaintenanceWindowStartTimeUpdate { get; set; }
            public System.String ApplicationName { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.UpdateApplicationMaintenanceConfigurationResponse, UpdateKINA2ApplicationMaintenanceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
