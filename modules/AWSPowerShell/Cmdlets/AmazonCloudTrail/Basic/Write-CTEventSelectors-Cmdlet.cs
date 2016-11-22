/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Configures an event selector for your trail. Use event selectors to specify the type
    /// of events that you want your trail to log. When an event occurs in your account, CloudTrail
    /// evaluates the event selectors in all trails. For each trail, if the event matches
    /// any event selector, the trail processes and logs the event. If the event doesn't match
    /// any event selector, the trail doesn't log the event. 
    /// 
    ///  
    /// <para>
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
    /// The <code>GetConsoleOutput</code> is a read-only event but it doesn't match your event
    /// selector. The trail doesn't log the event. 
    /// </para></li></ol><para>
    /// The <code>PutEventSelectors</code> operation must be called from the region in which
    /// the trail was created; otherwise, an <code>InvalidHomeRegionException</code> is thrown.
    /// </para><para>
    /// You can configure up to five event selectors for each trail. For more information,
    /// see <a href="http://docs.aws.amazon.com/awscloudtrail/latest/userguide/create-event-selectors-for-a-trail.html">Configuring
    /// Event Selectors for Trails</a> in the <i>AWS CloudTrail User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CTEventSelectors", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.PutEventSelectorsResponse")]
    [AWSCmdlet("Invokes the PutEventSelectors operation against AWS CloudTrail.", Operation = new[] {"PutEventSelectors"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.PutEventSelectorsResponse",
        "This cmdlet returns a Amazon.CloudTrail.Model.PutEventSelectorsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCTEventSelectorsCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter EventSelector
        /// <summary>
        /// <para>
        /// <para>Specifies the settings for your event selectors. You can configure up to five event
        /// selectors for a trail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventSelectors")]
        public Amazon.CloudTrail.Model.EventSelector[] EventSelector { get; set; }
        #endregion
        
        #region Parameter TrailName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the trail or trail ARN. If you specify a trail name, the string
        /// must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), periods (.), underscores (_),
        /// or dashes (-)</para></li><li><para>Start with a letter or number, and end with a letter or number</para></li><li><para>Be between 3 and 128 characters</para></li><li><para>Have no adjacent periods, underscores or dashes. Names like <code>my-_namespace</code>
        /// and <code>my--namespace</code> are invalid.</para></li><li><para>Not be in IP address format (for example, 192.168.5.4)</para></li></ul><para>If you specify a trail ARN, it must be in the format:</para><para><code>arn:aws:cloudtrail:us-east-1:123456789012:trail/MyTrail</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrailName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TrailName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CTEventSelectors (PutEventSelectors)"))
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
            
            if (this.EventSelector != null)
            {
                context.EventSelectors = new List<Amazon.CloudTrail.Model.EventSelector>(this.EventSelector);
            }
            context.TrailName = this.TrailName;
            
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
            
            if (cmdletContext.EventSelectors != null)
            {
                request.EventSelectors = cmdletContext.EventSelectors;
            }
            if (cmdletContext.TrailName != null)
            {
                request.TrailName = cmdletContext.TrailName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.CloudTrail.Model.PutEventSelectorsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.PutEventSelectorsRequest request)
        {
            #if DESKTOP
            return client.PutEventSelectors(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutEventSelectorsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.CloudTrail.Model.EventSelector> EventSelectors { get; set; }
            public System.String TrailName { get; set; }
        }
        
    }
}
