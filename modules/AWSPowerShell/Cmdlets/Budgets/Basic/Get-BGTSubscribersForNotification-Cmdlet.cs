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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Lists the subscribers that are associated with a notification.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BGTSubscribersForNotification")]
    [OutputType("Amazon.Budgets.Model.Subscriber")]
    [AWSCmdlet("Calls the AWS Budgets DescribeSubscribersForNotification API operation.", Operation = new[] {"DescribeSubscribersForNotification"}, SelectReturnType = typeof(Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse))]
    [AWSCmdletOutput("Amazon.Budgets.Model.Subscriber or Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse",
        "This cmdlet returns a collection of Amazon.Budgets.Model.Subscriber objects.",
        "The service call response (type Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetBGTSubscribersForNotificationCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>accountId</code> that is associated with the budget whose subscribers you
        /// want descriptions of.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of the budget whose subscribers you want descriptions of.</para>
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
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter Notification_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison that's used for this notification.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationState
        /// <summary>
        /// <para>
        /// <para>Specifies whether this notification is in alarm. If a budget notification is in the
        /// <code>ALARM</code> state, you passed the set threshold for the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Budgets.NotificationState")]
        public Amazon.Budgets.NotificationState Notification_NotificationState { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is for how much you have spent (<code>ACTUAL</code>)
        /// or for how much that you're forecasted to spend (<code>FORECASTED</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
        #endregion
        
        #region Parameter Notification_Threshold
        /// <summary>
        /// <para>
        /// <para>The threshold that's associated with a notification. Thresholds are always a percentage,
        /// and many customers find value being alerted between 50% - 200% of the budgeted amount.
        /// The maximum limit for your threshold is 1,000,000% above the budgeted amount.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? Notification_Threshold { get; set; }
        #endregion
        
        #region Parameter Notification_ThresholdType
        /// <summary>
        /// <para>
        /// <para>The type of threshold for a notification. For <code>ABSOLUTE_VALUE</code> thresholds,
        /// Amazon Web Services notifies you when you go over or are forecasted to go over your
        /// total cost threshold. For <code>PERCENTAGE</code> thresholds, Amazon Web Services
        /// notifies you when you go over or are forecasted to go over a certain percentage of
        /// your forecasted spend. For example, if you have a budget for 200 dollars and you have
        /// a <code>PERCENTAGE</code> threshold of 80%, Amazon Web Services notifies you when
        /// you go over 160 dollars.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Budgets.ThresholdType")]
        public Amazon.Budgets.ThresholdType Notification_ThresholdType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional integer that represents how many entries a paginated response contains.
        /// The maximum is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that you include in your request to indicate the next set of
        /// results that you want to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subscribers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse).
        /// Specifying the name of a property of type Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subscribers";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BudgetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BudgetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BudgetName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse, GetBGTSubscribersForNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BudgetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BudgetName = this.BudgetName;
            #if MODULAR
            if (this.BudgetName == null && ParameterWasBound(nameof(this.BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Notification_ComparisonOperator = this.Notification_ComparisonOperator;
            #if MODULAR
            if (this.Notification_ComparisonOperator == null && ParameterWasBound(nameof(this.Notification_ComparisonOperator)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_ComparisonOperator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_NotificationState = this.Notification_NotificationState;
            context.Notification_NotificationType = this.Notification_NotificationType;
            #if MODULAR
            if (this.Notification_NotificationType == null && ParameterWasBound(nameof(this.Notification_NotificationType)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_NotificationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_Threshold = this.Notification_Threshold;
            #if MODULAR
            if (this.Notification_Threshold == null && ParameterWasBound(nameof(this.Notification_Threshold)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_Threshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_ThresholdType = this.Notification_ThresholdType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Budgets.Model.DescribeSubscribersForNotificationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Notification
            var requestNotificationIsNull = true;
            request.Notification = new Amazon.Budgets.Model.Notification();
            Amazon.Budgets.ComparisonOperator requestNotification_notification_ComparisonOperator = null;
            if (cmdletContext.Notification_ComparisonOperator != null)
            {
                requestNotification_notification_ComparisonOperator = cmdletContext.Notification_ComparisonOperator;
            }
            if (requestNotification_notification_ComparisonOperator != null)
            {
                request.Notification.ComparisonOperator = requestNotification_notification_ComparisonOperator;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationState requestNotification_notification_NotificationState = null;
            if (cmdletContext.Notification_NotificationState != null)
            {
                requestNotification_notification_NotificationState = cmdletContext.Notification_NotificationState;
            }
            if (requestNotification_notification_NotificationState != null)
            {
                request.Notification.NotificationState = requestNotification_notification_NotificationState;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationType requestNotification_notification_NotificationType = null;
            if (cmdletContext.Notification_NotificationType != null)
            {
                requestNotification_notification_NotificationType = cmdletContext.Notification_NotificationType;
            }
            if (requestNotification_notification_NotificationType != null)
            {
                request.Notification.NotificationType = requestNotification_notification_NotificationType;
                requestNotificationIsNull = false;
            }
            System.Double? requestNotification_notification_Threshold = null;
            if (cmdletContext.Notification_Threshold != null)
            {
                requestNotification_notification_Threshold = cmdletContext.Notification_Threshold.Value;
            }
            if (requestNotification_notification_Threshold != null)
            {
                request.Notification.Threshold = requestNotification_notification_Threshold.Value;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.ThresholdType requestNotification_notification_ThresholdType = null;
            if (cmdletContext.Notification_ThresholdType != null)
            {
                requestNotification_notification_ThresholdType = cmdletContext.Notification_ThresholdType;
            }
            if (requestNotification_notification_ThresholdType != null)
            {
                request.Notification.ThresholdType = requestNotification_notification_ThresholdType;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.Budgets.Model.DescribeSubscribersForNotificationRequest();
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate Notification
            var requestNotificationIsNull = true;
            request.Notification = new Amazon.Budgets.Model.Notification();
            Amazon.Budgets.ComparisonOperator requestNotification_notification_ComparisonOperator = null;
            if (cmdletContext.Notification_ComparisonOperator != null)
            {
                requestNotification_notification_ComparisonOperator = cmdletContext.Notification_ComparisonOperator;
            }
            if (requestNotification_notification_ComparisonOperator != null)
            {
                request.Notification.ComparisonOperator = requestNotification_notification_ComparisonOperator;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationState requestNotification_notification_NotificationState = null;
            if (cmdletContext.Notification_NotificationState != null)
            {
                requestNotification_notification_NotificationState = cmdletContext.Notification_NotificationState;
            }
            if (requestNotification_notification_NotificationState != null)
            {
                request.Notification.NotificationState = requestNotification_notification_NotificationState;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationType requestNotification_notification_NotificationType = null;
            if (cmdletContext.Notification_NotificationType != null)
            {
                requestNotification_notification_NotificationType = cmdletContext.Notification_NotificationType;
            }
            if (requestNotification_notification_NotificationType != null)
            {
                request.Notification.NotificationType = requestNotification_notification_NotificationType;
                requestNotificationIsNull = false;
            }
            System.Double? requestNotification_notification_Threshold = null;
            if (cmdletContext.Notification_Threshold != null)
            {
                requestNotification_notification_Threshold = cmdletContext.Notification_Threshold.Value;
            }
            if (requestNotification_notification_Threshold != null)
            {
                request.Notification.Threshold = requestNotification_notification_Threshold.Value;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.ThresholdType requestNotification_notification_ThresholdType = null;
            if (cmdletContext.Notification_ThresholdType != null)
            {
                requestNotification_notification_ThresholdType = cmdletContext.Notification_ThresholdType;
            }
            if (requestNotification_notification_ThresholdType != null)
            {
                request.Notification.ThresholdType = requestNotification_notification_ThresholdType;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.Subscribers.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.DescribeSubscribersForNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "DescribeSubscribersForNotification");
            try
            {
                #if DESKTOP
                return client.DescribeSubscribersForNotification(request);
                #elif CORECLR
                return client.DescribeSubscribersForNotificationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String BudgetName { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
            public Amazon.Budgets.NotificationState Notification_NotificationState { get; set; }
            public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
            public System.Double? Notification_Threshold { get; set; }
            public Amazon.Budgets.ThresholdType Notification_ThresholdType { get; set; }
            public System.Func<Amazon.Budgets.Model.DescribeSubscribersForNotificationResponse, GetBGTSubscribersForNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subscribers;
        }
        
    }
}
