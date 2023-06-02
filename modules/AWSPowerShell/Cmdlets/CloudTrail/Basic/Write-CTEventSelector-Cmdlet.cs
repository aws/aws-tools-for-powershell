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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Configures an event selector or advanced event selectors for your trail. Use event
    /// selectors or advanced event selectors to specify management and data event settings
    /// for your trail. If you want your trail to log Insights events, be sure the event selector
    /// enables logging of the Insights event types you want configured for your trail. For
    /// more information about logging Insights events, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-insights-events-with-cloudtrail.html">Logging
    /// Insights events for trails</a> in the <i>CloudTrail User Guide</i>. By default, trails
    /// created without specific event selectors are configured to log all read and write
    /// management events, and no data events.
    /// 
    ///  
    /// <para>
    /// When an event occurs in your account, CloudTrail evaluates the event selectors or
    /// advanced event selectors in all trails. For each trail, if the event matches any event
    /// selector, the trail processes and logs the event. If the event doesn't match any event
    /// selector, the trail doesn't log the event.
    /// </para><para>
    /// Example
    /// </para><ol><li><para>
    /// You create an event selector for a trail and specify that you want write-only events.
    /// </para></li><li><para>
    /// The EC2 <code>GetConsoleOutput</code> and <code>RunInstances</code> API operations
    /// occur in your account.
    /// </para></li><li><para>
    /// CloudTrail evaluates whether the events match your event selectors.
    /// </para></li><li><para>
    /// The <code>RunInstances</code> is a write-only event and it matches your event selector.
    /// The trail logs the event.
    /// </para></li><li><para>
    /// The <code>GetConsoleOutput</code> is a read-only event that doesn't match your event
    /// selector. The trail doesn't log the event. 
    /// </para></li></ol><para>
    /// The <code>PutEventSelectors</code> operation must be called from the Region in which
    /// the trail was created; otherwise, an <code>InvalidHomeRegionException</code> exception
    /// is thrown.
    /// </para><para>
    /// You can configure up to five event selectors for each trail. For more information,
    /// see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-management-events-with-cloudtrail.html">Logging
    /// management events</a>, <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-data-events-with-cloudtrail.html">Logging
    /// data events</a>, and <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/WhatIsCloudTrail-Limits.html">Quotas
    /// in CloudTrail</a> in the <i>CloudTrail User Guide</i>.
    /// </para><para>
    /// You can add advanced event selectors, and conditions for your advanced event selectors,
    /// up to a maximum of 500 values for all conditions and selectors on a trail. You can
    /// use either <code>AdvancedEventSelectors</code> or <code>EventSelectors</code>, but
    /// not both. If you apply <code>AdvancedEventSelectors</code> to a trail, any existing
    /// <code>EventSelectors</code> are overwritten. For more information about advanced event
    /// selectors, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-data-events-with-cloudtrail.html">Logging
    /// data events</a> in the <i>CloudTrail User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CTEventSelector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.PutEventSelectorsResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail PutEventSelectors API operation.", Operation = new[] {"PutEventSelectors"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.PutEventSelectorsResponse), LegacyAlias="Write-CTEventSelectors")]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.PutEventSelectorsResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.PutEventSelectorsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCTEventSelectorCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter AdvancedEventSelector
        /// <summary>
        /// <para>
        /// <para> Specifies the settings for advanced event selectors. You can add advanced event selectors,
        /// and conditions for your advanced event selectors, up to a maximum of 500 values for
        /// all conditions and selectors on a trail. You can use either <code>AdvancedEventSelectors</code>
        /// or <code>EventSelectors</code>, but not both. If you apply <code>AdvancedEventSelectors</code>
        /// to a trail, any existing <code>EventSelectors</code> are overwritten. For more information
        /// about advanced event selectors, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-data-events-with-cloudtrail.html">Logging
        /// data events</a> in the <i>CloudTrail User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedEventSelectors")]
        public Amazon.CloudTrail.Model.AdvancedEventSelector[] AdvancedEventSelector { get; set; }
        #endregion
        
        #region Parameter EventSelector
        /// <summary>
        /// <para>
        /// <para>Specifies the settings for your event selectors. You can configure up to five event
        /// selectors for a trail. You can use either <code>EventSelectors</code> or <code>AdvancedEventSelectors</code>
        /// in a <code>PutEventSelectors</code> request, but not both. If you apply <code>EventSelectors</code>
        /// to a trail, any existing <code>AdvancedEventSelectors</code> are overwritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventSelectors")]
        public Amazon.CloudTrail.Model.EventSelector[] EventSelector { get; set; }
        #endregion
        
        #region Parameter TrailName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the trail or trail ARN. If you specify a trail name, the string
        /// must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), periods (.), underscores (_),
        /// or dashes (-)</para></li><li><para>Start with a letter or number, and end with a letter or number</para></li><li><para>Be between 3 and 128 characters</para></li><li><para>Have no adjacent periods, underscores or dashes. Names like <code>my-_namespace</code>
        /// and <code>my--namespace</code> are not valid.</para></li><li><para>Not be in IP address format (for example, 192.168.5.4)</para></li></ul><para>If you specify a trail ARN, it must be in the following format.</para><para><code>arn:aws:cloudtrail:us-east-2:123456789012:trail/MyTrail</code></para>
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
        public System.String TrailName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.PutEventSelectorsResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.PutEventSelectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrailName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrailName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrailName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrailName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CTEventSelector (PutEventSelectors)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.PutEventSelectorsResponse, WriteCTEventSelectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrailName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdvancedEventSelector != null)
            {
                context.AdvancedEventSelector = new List<Amazon.CloudTrail.Model.AdvancedEventSelector>(this.AdvancedEventSelector);
            }
            if (this.EventSelector != null)
            {
                context.EventSelector = new List<Amazon.CloudTrail.Model.EventSelector>(this.EventSelector);
            }
            context.TrailName = this.TrailName;
            #if MODULAR
            if (this.TrailName == null && ParameterWasBound(nameof(this.TrailName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrailName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudTrail.Model.PutEventSelectorsRequest();
            
            if (cmdletContext.AdvancedEventSelector != null)
            {
                request.AdvancedEventSelectors = cmdletContext.AdvancedEventSelector;
            }
            if (cmdletContext.EventSelector != null)
            {
                request.EventSelectors = cmdletContext.EventSelector;
            }
            if (cmdletContext.TrailName != null)
            {
                request.TrailName = cmdletContext.TrailName;
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
        
        private Amazon.CloudTrail.Model.PutEventSelectorsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.PutEventSelectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "PutEventSelectors");
            try
            {
                #if DESKTOP
                return client.PutEventSelectors(request);
                #elif CORECLR
                return client.PutEventSelectorsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudTrail.Model.AdvancedEventSelector> AdvancedEventSelector { get; set; }
            public List<Amazon.CloudTrail.Model.EventSelector> EventSelector { get; set; }
            public System.String TrailName { get; set; }
            public System.Func<Amazon.CloudTrail.Model.PutEventSelectorsResponse, WriteCTEventSelectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
