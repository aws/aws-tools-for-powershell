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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Creates an AWS Firewall Manager protocols list.
    /// </summary>
    [Cmdlet("Write", "FMSProtocolList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FMS.Model.PutProtocolsListResponse")]
    [AWSCmdlet("Calls the Firewall Management Service PutProtocolsList API operation.", Operation = new[] {"PutProtocolsList"}, SelectReturnType = typeof(Amazon.FMS.Model.PutProtocolsListResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.PutProtocolsListResponse",
        "This cmdlet returns an Amazon.FMS.Model.PutProtocolsListResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteFMSProtocolListCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        #region Parameter ProtocolsList_CreateTime
        /// <summary>
        /// <para>
        /// <para>The time that the AWS Firewall Manager protocols list was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ProtocolsList_CreateTime { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_LastUpdateTime
        /// <summary>
        /// <para>
        /// <para>The time that the AWS Firewall Manager protocols list was last updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ProtocolsList_LastUpdateTime { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_ListId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Firewall Manager protocols list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtocolsList_ListId { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_ListName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS Firewall Manager protocols list.</para>
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
        public System.String ProtocolsList_ListName { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_ListUpdateToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for each update to the list. When you update the list, the update
        /// token must match the token of the current version of the application list. You can
        /// retrieve the update token by getting the list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtocolsList_ListUpdateToken { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_PreviousProtocolsList
        /// <summary>
        /// <para>
        /// <para>A map of previous version numbers to their corresponding protocol arrays.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ProtocolsList_PreviousProtocolsList { get; set; }
        #endregion
        
        #region Parameter ProtocolsList_ProtocolsList
        /// <summary>
        /// <para>
        /// <para>An array of protocols in the AWS Firewall Manager protocols list.</para>
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
        public System.String[] ProtocolsList_ProtocolsList { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para>The tags associated with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FMS.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.PutProtocolsListResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.PutProtocolsListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProtocolsList_ListName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProtocolsList_ListName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProtocolsList_ListName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProtocolsList_ListName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FMSProtocolList (PutProtocolsList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.PutProtocolsListResponse, WriteFMSProtocolListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProtocolsList_ListName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ProtocolsList_CreateTime = this.ProtocolsList_CreateTime;
            context.ProtocolsList_LastUpdateTime = this.ProtocolsList_LastUpdateTime;
            context.ProtocolsList_ListId = this.ProtocolsList_ListId;
            context.ProtocolsList_ListName = this.ProtocolsList_ListName;
            #if MODULAR
            if (this.ProtocolsList_ListName == null && ParameterWasBound(nameof(this.ProtocolsList_ListName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtocolsList_ListName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtocolsList_ListUpdateToken = this.ProtocolsList_ListUpdateToken;
            if (this.ProtocolsList_PreviousProtocolsList != null)
            {
                context.ProtocolsList_PreviousProtocolsList = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProtocolsList_PreviousProtocolsList.Keys)
                {
                    object hashValue = this.ProtocolsList_PreviousProtocolsList[hashKey];
                    if (hashValue == null)
                    {
                        context.ProtocolsList_PreviousProtocolsList.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.ProtocolsList_PreviousProtocolsList.Add((String)hashKey, valueSet);
                }
            }
            if (this.ProtocolsList_ProtocolsList != null)
            {
                context.ProtocolsList_ProtocolsList = new List<System.String>(this.ProtocolsList_ProtocolsList);
            }
            #if MODULAR
            if (this.ProtocolsList_ProtocolsList == null && ParameterWasBound(nameof(this.ProtocolsList_ProtocolsList)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtocolsList_ProtocolsList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.FMS.Model.Tag>(this.TagList);
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
            var request = new Amazon.FMS.Model.PutProtocolsListRequest();
            
            
             // populate ProtocolsList
            var requestProtocolsListIsNull = true;
            request.ProtocolsList = new Amazon.FMS.Model.ProtocolsListData();
            System.DateTime? requestProtocolsList_protocolsList_CreateTime = null;
            if (cmdletContext.ProtocolsList_CreateTime != null)
            {
                requestProtocolsList_protocolsList_CreateTime = cmdletContext.ProtocolsList_CreateTime.Value;
            }
            if (requestProtocolsList_protocolsList_CreateTime != null)
            {
                request.ProtocolsList.CreateTime = requestProtocolsList_protocolsList_CreateTime.Value;
                requestProtocolsListIsNull = false;
            }
            System.DateTime? requestProtocolsList_protocolsList_LastUpdateTime = null;
            if (cmdletContext.ProtocolsList_LastUpdateTime != null)
            {
                requestProtocolsList_protocolsList_LastUpdateTime = cmdletContext.ProtocolsList_LastUpdateTime.Value;
            }
            if (requestProtocolsList_protocolsList_LastUpdateTime != null)
            {
                request.ProtocolsList.LastUpdateTime = requestProtocolsList_protocolsList_LastUpdateTime.Value;
                requestProtocolsListIsNull = false;
            }
            System.String requestProtocolsList_protocolsList_ListId = null;
            if (cmdletContext.ProtocolsList_ListId != null)
            {
                requestProtocolsList_protocolsList_ListId = cmdletContext.ProtocolsList_ListId;
            }
            if (requestProtocolsList_protocolsList_ListId != null)
            {
                request.ProtocolsList.ListId = requestProtocolsList_protocolsList_ListId;
                requestProtocolsListIsNull = false;
            }
            System.String requestProtocolsList_protocolsList_ListName = null;
            if (cmdletContext.ProtocolsList_ListName != null)
            {
                requestProtocolsList_protocolsList_ListName = cmdletContext.ProtocolsList_ListName;
            }
            if (requestProtocolsList_protocolsList_ListName != null)
            {
                request.ProtocolsList.ListName = requestProtocolsList_protocolsList_ListName;
                requestProtocolsListIsNull = false;
            }
            System.String requestProtocolsList_protocolsList_ListUpdateToken = null;
            if (cmdletContext.ProtocolsList_ListUpdateToken != null)
            {
                requestProtocolsList_protocolsList_ListUpdateToken = cmdletContext.ProtocolsList_ListUpdateToken;
            }
            if (requestProtocolsList_protocolsList_ListUpdateToken != null)
            {
                request.ProtocolsList.ListUpdateToken = requestProtocolsList_protocolsList_ListUpdateToken;
                requestProtocolsListIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestProtocolsList_protocolsList_PreviousProtocolsList = null;
            if (cmdletContext.ProtocolsList_PreviousProtocolsList != null)
            {
                requestProtocolsList_protocolsList_PreviousProtocolsList = cmdletContext.ProtocolsList_PreviousProtocolsList;
            }
            if (requestProtocolsList_protocolsList_PreviousProtocolsList != null)
            {
                request.ProtocolsList.PreviousProtocolsList = requestProtocolsList_protocolsList_PreviousProtocolsList;
                requestProtocolsListIsNull = false;
            }
            List<System.String> requestProtocolsList_protocolsList_ProtocolsList = null;
            if (cmdletContext.ProtocolsList_ProtocolsList != null)
            {
                requestProtocolsList_protocolsList_ProtocolsList = cmdletContext.ProtocolsList_ProtocolsList;
            }
            if (requestProtocolsList_protocolsList_ProtocolsList != null)
            {
                request.ProtocolsList.ProtocolsList = requestProtocolsList_protocolsList_ProtocolsList;
                requestProtocolsListIsNull = false;
            }
             // determine if request.ProtocolsList should be set to null
            if (requestProtocolsListIsNull)
            {
                request.ProtocolsList = null;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
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
        
        private Amazon.FMS.Model.PutProtocolsListResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.PutProtocolsListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "PutProtocolsList");
            try
            {
                #if DESKTOP
                return client.PutProtocolsList(request);
                #elif CORECLR
                return client.PutProtocolsListAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ProtocolsList_CreateTime { get; set; }
            public System.DateTime? ProtocolsList_LastUpdateTime { get; set; }
            public System.String ProtocolsList_ListId { get; set; }
            public System.String ProtocolsList_ListName { get; set; }
            public System.String ProtocolsList_ListUpdateToken { get; set; }
            public Dictionary<System.String, List<System.String>> ProtocolsList_PreviousProtocolsList { get; set; }
            public List<System.String> ProtocolsList_ProtocolsList { get; set; }
            public List<Amazon.FMS.Model.Tag> TagList { get; set; }
            public System.Func<Amazon.FMS.Model.PutProtocolsListResponse, WriteFMSProtocolListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
