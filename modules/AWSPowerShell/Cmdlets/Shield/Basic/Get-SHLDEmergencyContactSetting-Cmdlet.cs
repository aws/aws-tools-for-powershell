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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// A list of email addresses and phone numbers that the Shield Response Team (SRT) can
    /// use to contact you if you have proactive engagement enabled, for escalations to the
    /// SRT and to initiate proactive customer support.
    /// </summary>
    [Cmdlet("Get", "SHLDEmergencyContactSetting")]
    [OutputType("Amazon.Shield.Model.EmergencyContact")]
    [AWSCmdlet("Calls the AWS Shield DescribeEmergencyContactSettings API operation.", Operation = new[] {"DescribeEmergencyContactSettings"}, SelectReturnType = typeof(Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.EmergencyContact or Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse",
        "This cmdlet returns a collection of Amazon.Shield.Model.EmergencyContact objects.",
        "The service call response (type Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHLDEmergencyContactSettingCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmergencyContactList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmergencyContactList";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse, GetSHLDEmergencyContactSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Shield.Model.DescribeEmergencyContactSettingsRequest();
            
            
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
        
        private Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.DescribeEmergencyContactSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "DescribeEmergencyContactSettings");
            try
            {
                #if DESKTOP
                return client.DescribeEmergencyContactSettings(request);
                #elif CORECLR
                return client.DescribeEmergencyContactSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Shield.Model.DescribeEmergencyContactSettingsResponse, GetSHLDEmergencyContactSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmergencyContactList;
        }
        
    }
}
