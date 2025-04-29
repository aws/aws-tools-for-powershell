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
using System.Threading;
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates and updates the retention configuration with details about retention period
    /// (number of days) that Config stores your historical information. The API creates the
    /// <c>RetentionConfiguration</c> object and names the object as <b>default</b>. When
    /// you have a <c>RetentionConfiguration</c> object named <b>default</b>, calling the
    /// API modifies the default object. 
    /// 
    ///  <note><para>
    /// Currently, Config supports only one retention configuration per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGRetentionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.RetentionConfiguration")]
    [AWSCmdlet("Calls the AWS Config PutRetentionConfiguration API operation.", Operation = new[] {"PutRetentionConfiguration"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutRetentionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.RetentionConfiguration or Amazon.ConfigService.Model.PutRetentionConfigurationResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.RetentionConfiguration object.",
        "The service call response (type Amazon.ConfigService.Model.PutRetentionConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGRetentionConfigurationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>Number of days Config stores your historical information.</para><note><para>Currently, only applicable to the configuration item history.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetentionPeriodInDays")]
        public System.Int32? RetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RetentionConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutRetentionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutRetentionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RetentionConfiguration";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RetentionPeriodInDay), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGRetentionConfiguration (PutRetentionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutRetentionConfigurationResponse, WriteCFGRetentionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RetentionPeriodInDay = this.RetentionPeriodInDay;
            #if MODULAR
            if (this.RetentionPeriodInDay == null && ParameterWasBound(nameof(this.RetentionPeriodInDay)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionPeriodInDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.PutRetentionConfigurationRequest();
            
            if (cmdletContext.RetentionPeriodInDay != null)
            {
                request.RetentionPeriodInDays = cmdletContext.RetentionPeriodInDay.Value;
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
        
        private Amazon.ConfigService.Model.PutRetentionConfigurationResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutRetentionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutRetentionConfiguration");
            try
            {
                return client.PutRetentionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? RetentionPeriodInDay { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutRetentionConfigurationResponse, WriteCFGRetentionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RetentionConfiguration;
        }
        
    }
}
