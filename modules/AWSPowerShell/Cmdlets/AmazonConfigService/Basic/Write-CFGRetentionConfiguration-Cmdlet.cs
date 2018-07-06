/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates and updates the retention configuration with details about retention period
    /// (number of days) that AWS Config stores your historical information. The API creates
    /// the <code>RetentionConfiguration</code> object and names the object as <b>default</b>.
    /// When you have a <code>RetentionConfiguration</code> object named <b>default</b>, calling
    /// the API modifies the default object. 
    /// 
    ///  <note><para>
    /// Currently, AWS Config supports only one retention configuration per region in your
    /// account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGRetentionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.RetentionConfiguration")]
    [AWSCmdlet("Calls the AWS Config PutRetentionConfiguration API operation.", Operation = new[] {"PutRetentionConfiguration"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.RetentionConfiguration",
        "This cmdlet returns a RetentionConfiguration object.",
        "The service call response (type Amazon.ConfigService.Model.PutRetentionConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGRetentionConfigurationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>Number of days AWS Config stores your historical information.</para><note><para>Currently, only applicable to the configuration item history.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("RetentionPeriodInDays")]
        public System.Int32 RetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RetentionPeriodInDay", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGRetentionConfiguration (PutRetentionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("RetentionPeriodInDay"))
                context.RetentionPeriodInDays = this.RetentionPeriodInDay;
            
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
            
            if (cmdletContext.RetentionPeriodInDays != null)
            {
                request.RetentionPeriodInDays = cmdletContext.RetentionPeriodInDays.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RetentionConfiguration;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.PutRetentionConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutRetentionConfigurationAsync(request);
                return task.Result;
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
            public System.Int32? RetentionPeriodInDays { get; set; }
        }
        
    }
}
