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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Gets the state of the AWS Systems Manager Change Calendar at an optional, specified
    /// time. If you specify a time, <code>GetCalendarState</code> returns the state of the
    /// calendar at a specific time, and returns the next time that the Change Calendar state
    /// will transition. If you do not specify a time, <code>GetCalendarState</code> assumes
    /// the current time. Change Calendar entries have two possible states: <code>OPEN</code>
    /// or <code>CLOSED</code>. For more information about Systems Manager Change Calendar,
    /// see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-change-calendar.html">AWS
    /// Systems Manager Change Calendar</a> in the <i>AWS Systems Manager User Guide</i>.
    /// </summary>
    [Cmdlet("Get", "SSMCalendarState")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetCalendarState API operation.", Operation = new[] {"GetCalendarState"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSSMCalendarStateCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AtTime
        /// <summary>
        /// <para>
        /// <para>(Optional) The specific time for which you want to get calendar state information,
        /// in <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a> format. If you do
        /// not add <code>AtTime</code>, the current time is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AtTime { get; set; }
        #endregion
        
        #region Parameter CalendarName
        /// <summary>
        /// <para>
        /// <para>The names or Amazon Resource Names (ARNs) of the Systems Manager documents that represent
        /// the calendar entries for which you want to get the state.</para>
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
        [Alias("CalendarNames")]
        public System.String[] CalendarName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AtTime parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AtTime' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AtTime' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse, GetSSMCalendarStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AtTime;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AtTime = this.AtTime;
            if (this.CalendarName != null)
            {
                context.CalendarName = new List<System.String>(this.CalendarName);
            }
            #if MODULAR
            if (this.CalendarName == null && ParameterWasBound(nameof(this.CalendarName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalendarName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetCalendarStateRequest();
            
            if (cmdletContext.AtTime != null)
            {
                request.AtTime = cmdletContext.AtTime;
            }
            if (cmdletContext.CalendarName != null)
            {
                request.CalendarNames = cmdletContext.CalendarName;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetCalendarStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetCalendarState");
            try
            {
                #if DESKTOP
                return client.GetCalendarState(request);
                #elif CORECLR
                return client.GetCalendarStateAsync(request).GetAwaiter().GetResult();
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
            public System.String AtTime { get; set; }
            public List<System.String> CalendarName { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetCalendarStateResponse, GetSSMCalendarStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
